using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using Warehouse_IO.Common;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Warehouse_IO.View.OutboundSource
{
    public partial class Add : AddEdit_Outbound_Form
    {
        Outbound add;
        Outbound newOutbound; //After create shipment use this instance to work with truck & product.
        static string connstr = Settings.Default.CONNECTION_STRING; //After create shipment ask shipment ID to Database

        //Variable for update components
        List<Supplier> supplierList;
        List<Truck> truckList;
        List<Deliveryplace> deliveryplaceList;
        List<Product> productList;

        //Variable for compare selected Index when create shipment
        private List<int> supplierID = new List<int>();
        private List<int> truckID = new List<int>();

        //Variable for tracking deliveryplace after filtered
        private readonly Dictionary<string, Deliveryplace> deliveryplaceNameToDeliveryplace = new Dictionary<string, Deliveryplace>();
       
        //Variable for create selected object on CreateNewShipment()
        Supplier supplier;
        Truck truck;
        Deliveryplace deliveryplace;
        Product product;
        DateTime deliverydate;

        //Edit quantity pop-Up window components
        EditQuantityWindow editQuantity;
        MainForm main;

        //Event to Invoke Update Outbound List
        public event EventHandler UpdateGrid;

        //Variable for Importfile
        Excel.Application excelApp;
        Excel.Workbook workbook;
        Excel.Worksheet worksheet;
        Excel.Range range;

        public Add()
        {
            InitializeComponent();
            //Create instance for update components
            supplierList = new List<Supplier>();
            truckList = new List<Truck>();
            deliveryplaceList = new List<Deliveryplace>();
            productList = new List<Product>();

            //Create instance for edit quantity pop-Up window components
            editQuantity = new EditQuantityWindow();
            main = new MainForm();
         
            deliveryPlaceDatagridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            truckDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            productListDatagridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //Lock component at truck and product section
            truckGroupBox.Enabled = false;
            productGroupBox.Enabled = false;
            deliveryPlaceGroupBox.Enabled = false;

            updateComponent();
        }

        private void updateComponent()
        {
            supplierList = Supplier.GetSupplierList();
            supplierList.Sort((x, y) => x.Name.CompareTo(y.Name));
            supplierComboBox.Items.Clear();
            foreach (Supplier supplier in supplierList)
            {
                supplierComboBox.Items.Add(supplier.Name);
                supplierID.Add(supplier.ID);
            }

            deliveryplaceList = Deliveryplace.GetDeliveryplaceList();
            deliveryplaceList.Sort((x, y) => x.Name.CompareTo(y.Name));
            deliveryplaceListBox.Items.Clear();
            foreach (Deliveryplace delivery in deliveryplaceList)
            {
                string displayedName = delivery.Name;
                deliveryplaceListBox.Items.Add(displayedName);

                deliveryplaceNameToDeliveryplace[displayedName] = delivery;
            }

            truckList = Truck.GetTruckList();
            truckList.Sort((x, y) => x.Description.CompareTo(y.Description));
            truckListBox.Items.Clear();
            foreach (Truck truck in truckList)
            {
                truckListBox.Items.Add(truck.Name);
                truckID.Add(truck.ID);
            }

            productList = Product.GetProductList();
            productList.Sort((x, y) => x.ID.CompareTo(y.ID));
            productListBox.Items.Clear();
            foreach (Product product in productList)
            {
                string displayedName = product.ID;
                productListBox.Items.Add(displayedName);
            }
        }

        private void UpdateTruckGridView()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Truck");
            datatable.Columns.Add("Quantity", typeof(int));
            datatable.Columns.Add("ID", typeof(int));
            foreach (KeyValuePair<Truck, int> truckGridlistEntry in newOutbound.TruckQuantityPerShipmentList)
            {
                Truck truck = truckGridlistEntry.Key;
                int quantity = truckGridlistEntry.Value;
                DataRow row = datatable.NewRow();
                row["Truck"] = truck.Name;
                row["Quantity"] = quantity;
                row["ID"] = truck.ID;
                datatable.Rows.Add(row);
            }
            datatable.DefaultView.Sort = "Truck ASC";
            truckDataGridView.DataSource = datatable.DefaultView;
        }
        private void UpdateProductGridView()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Name");
            datatable.Columns.Add("Quantity", typeof(int));
            datatable.Columns.Add("Details");
            datatable.Columns.Add("M3", typeof(double));
            foreach (KeyValuePair<Product, int> productGridlistEntry in newOutbound.QuantityOfProductList)
            {
                Product product = productGridlistEntry.Key;
                int quantity = productGridlistEntry.Value;
                DataRow row = datatable.NewRow();
                row["Name"] = product.ID;
                row["Quantity"] = quantity;
                row["Details"] = product.Name;

                Warehouse_IO.WHIO.Model.Dimension dimension = product.Dimension;
                if (dimension != null)
                {
                    double m3PerUnit = dimension.GetM3();
                    double totalM3PerItem = quantity * m3PerUnit;
                    row["M3"] = totalM3PerItem.ToString("0.00");
                }
                else
                {
                    row["M3"] = "0.00";
                }
                datatable.Rows.Add(row);
            }
            datatable.DefaultView.Sort = "Name DESC";
            productListDatagridView.DataSource = datatable.DefaultView;

        }
        private void UpdateDeliveryplaceGridView()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Name");
            datatable.Columns.Add("ID", typeof(int));
            foreach(Deliveryplace deliveryplace in newOutbound.DeliveryplaceList)
            {
                DataRow row = datatable.NewRow();
                row["Name"] = deliveryplace.Name;
                row["ID"] = deliveryplace.ID;
                datatable.Rows.Add(row);
            }
            datatable.DefaultView.Sort = "Name ASC";
            deliveryPlaceDatagridView.DataSource = datatable.DefaultView;
        }

        //Create new shipment
        private void CreateNewShipment()
        {
            int selectedSupplierIndex = supplierComboBox.SelectedIndex;
            if (selectedSupplierIndex >= 0 && selectedSupplierIndex < supplierID.Count)
            {
                int selectedSuppierID = supplierID[selectedSupplierIndex];
                supplier = new Supplier(selectedSuppierID);
            }
            else
            {
                MessageBox.Show(this, "Please select Supplier");
                return;
            }
            if (string.IsNullOrWhiteSpace(invoiceTextBox.Text))
            {
                MessageBox.Show(this, "Please enter Invoice");
                return;
            }
            if (deliveryDatedateTimePicker.Value != null)
            {
                deliverydate = deliveryDatedateTimePicker.Value;
            }
            else
            {
                MessageBox.Show(this, "Please select Delivery Date");
                return;
            }

            add = new Outbound(invoiceTextBox.Text, deliverydate, supplier, IsInterCheckBox.Checked);

            if (add.Create())
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID()";
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int newAddId = Convert.ToInt32(result);
                        newOutbound = new Outbound(newAddId);
                        MessageBox.Show(this, "Inbound Shipment Created with ID: " + newAddId);
                        shipmentGroupBox.Enabled = false;
                        truckGroupBox.Enabled = true;
                        productGroupBox.Enabled = true;
                        deliveryPlaceGroupBox.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(this, "Failed to retrieve Inbound ID.");
                    }
                    conn.Close();
                    return;
                }
            }
            else MessageBox.Show(this, "Create to Database Fail");
            return;
        }
        private void createShipmentButton_Click(object sender, EventArgs e)
        {
            CreateNewShipment();
        }

        //Add truck to shipment
        private void AddTruckToShipment()
        {
            if (truckListBox.SelectedItem != null)
            {
                int selectedTruckIndex = truckListBox.SelectedIndex;
                if (selectedTruckIndex >= 0 && selectedTruckIndex < truckID.Count)
                {
                    int selectedTruckID = truckID[selectedTruckIndex];
                    truck = new Truck(selectedTruckID);

                    if (!newOutbound.TruckQuantityPerShipmentList.ContainsKey(truck))
                    {
                        int quantity = int.Parse(quantityTruckTextBox.Text);
                        newOutbound.AddTruck(truck, quantity);
                        quantityTruckTextBox.Text = "";
                        UpdateTruckGridView();
                    }
                    else MessageBox.Show(this, "Same truck is added");
                }
            }
            else MessageBox.Show(this, "Please select truck & put quantity");
        }
        private void addButtonTruck_Click(object sender, EventArgs e)
        {
            int addQty;
            string qty = quantityTruckTextBox.Text;
            if (int.TryParse(qty, out addQty))
            {
                if (addQty > 0)
                {
                    AddTruckToShipment();
                }
            }
            else MessageBox.Show(this, "Need number more than 0");
        }
        private void quantityTruckTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int addQty;
                string qty = quantityTruckTextBox.Text;
                if (int.TryParse(qty, out addQty))
                {
                    if (addQty > 0)
                    {
                        AddTruckToShipment();
                    }
                }
                else MessageBox.Show(this, "Need number more than 0");
            }
        }

        //Edit truck quantity
        private void EditTruckQuantityFromShipment()
        {
            if (truckDataGridView.SelectedRows.Count > 0)
            {
                editQuantity.Owner = main;

                DataGridViewRow selectedRow = truckDataGridView.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells[2].Value);

                editQuantity.ShowDialog();

                int newQty = EditQuantityWindow.editQty;
                truck = new Truck(id);
                if (newOutbound.ChangeQuantityOfTruck(truck, newQty))
                {
                    UpdateTruckGridView();
                }
                else MessageBox.Show(this, "Edited Fail");
            }
        }
        private void editTruckQuantityButton_Click(object sender, EventArgs e)
        {
            EditTruckQuantityFromShipment();
        }

        //Remove truck from shipment
        private void RemoveTruckFromShipment()
        {
            if (truckDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = truckDataGridView.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells[2].Value);
                truck = new WHIO.Model.Truck(id);
                if (newOutbound.RemoveTruck(truck))
                {
                    UpdateTruckGridView();
                }
                else MessageBox.Show(this, "Remove Fails");
            }
        }
        private void removeTruckButton_Click_1(object sender, EventArgs e)
        {
            RemoveTruckFromShipment();
        }

        //Add product to shipment
        private void AddProductToShipment()
        {
            if (productListBox.SelectedIndex >= 0)
            {
                string selectedName = (string)productListBox.SelectedItem;

                    product = new Product(selectedName);
                    if (!newOutbound.QuantityOfProductList.ContainsKey(product))
                    {
                        double kgs = double.Parse(productQuantityTextBox.Text);
                        int kgsToQuantity = product.GetQuantity(kgs);
                        newOutbound.AddProduct(product, kgsToQuantity);
                        productQuantityTextBox.Text = "";
                        UpdateProductGridView();
                    }
                    else MessageBox.Show(this, "Same product is added");
            }
        }
        private void addProductButton_Click(object sender, EventArgs e)
        {
            int addQty;
            string qty = productQuantityTextBox.Text;
            if (int.TryParse(qty, out addQty))
            {
                if (addQty > 0)
                {
                    AddProductToShipment();
                }
            }
            else MessageBox.Show(this, "Need number more than 0");
        }
        private void productQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int addQty;
                string qty = productQuantityTextBox.Text;
                if (int.TryParse(qty, out addQty))
                {
                    if (addQty > 0)
                    {
                        AddProductToShipment();
                    }
                }
                else MessageBox.Show(this, "Need number more than 0");
            }
        }

        //Edit product quantity
        private void EditProductQuantity()
        {
            if (productListDatagridView.SelectedRows.Count > 0)
            {
                editQuantity.Owner = main;
                Global.tempPkeyName = null;
                DataGridViewRow selectedRow = productListDatagridView.CurrentRow;
                string id = (string)selectedRow.Cells["Name"].Value;
                Global.tempPkeyName = id;

                editQuantity.ShowDialog();

                int newQty = EditQuantityWindow.editQty;
                product = new Product(id);
                if (newOutbound.ChangeQuantityOfProduct(product, newQty))
                {
                    UpdateProductGridView();
                }
                else MessageBox.Show(this, "Edited fail");
            }
        }
        private void editProductQuantityButton_Click(object sender, EventArgs e)
        {
            EditProductQuantity();
        }

        //Remove product from shipment
        private void RemoveProductFromShipment()
        {
            if (productListDatagridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = productListDatagridView.CurrentRow;
                string id = (string)selectedRow.Cells["Name"].Value;
                product = new Product(id);
                if (newOutbound.RemoveProduct(product))
                {
                    UpdateProductGridView();
                }
                else MessageBox.Show(this, "Remove fails");
            }
        }
        private void removeProductButton_Click(object sender, EventArgs e)
        {
            RemoveProductFromShipment();
        }

        //Add Deliveryplace to shipment
        private void AddDeliveryplace()
        {
            if (deliveryplaceListBox.SelectedIndex >= 0)
            {
                string selectedName = (string)deliveryplaceListBox.SelectedItem;

                if (deliveryplaceNameToDeliveryplace.ContainsKey(selectedName))
                {
                    Deliveryplace selectedDeliveryplace = deliveryplaceNameToDeliveryplace[selectedName];
                    int selectedDeliveryplaceID = selectedDeliveryplace.ID;

                    deliveryplace = new Deliveryplace(selectedDeliveryplaceID);
                    newOutbound.AddDeliveryPlace(deliveryplace);
                    deliveryPlaceTextBox.Text = "";
                    UpdateDeliveryplaceGridView();
                }
                else
                {
                    MessageBox.Show(this, "Selected item not found in list.");
                }
            }
            else
            {
                MessageBox.Show(this, "Please select a delivery place.");
            }
        }
        private void addPlaceButton_Click(object sender, EventArgs e)
        {
            AddDeliveryplace();
        }
        private void deliveryplaceListBox_DoubleClick(object sender, EventArgs e)
        {
            AddDeliveryplace();
        }

        //Remove Deliveryplace from shipment
        private void RemoveDeliveryPlaceFromShipment()
        {
            DataGridViewRow selectedRow = deliveryPlaceDatagridView.CurrentRow;
            int id = Convert.ToInt32(selectedRow.Cells[1].Value);
            deliveryplace = new Deliveryplace(id);
            if (newOutbound.RemoveDeliveryPlace(deliveryplace))
            {
                UpdateDeliveryplaceGridView();
            }
            else MessageBox.Show(this, "Remove fails");
        }
        private void removePlaceButton_Click(object sender, EventArgs e)
        {
            RemoveDeliveryPlaceFromShipment();
        }

        //Check all are good !!
        private void CheckAllThings()
        {
            if (newOutbound != null)
            {
                newOutbound.UpdateDeliveryplace();
                newOutbound.UpdateProduct();
                newOutbound.UpdateTruck();
                if (newOutbound.TruckQuantityPerShipmentList.Values.Count == 0 && newOutbound.QuantityOfProductList.Values.Count == 0 && newOutbound.DeliveryplaceList.Count == 0)
                {
                    if (MessageBox.Show(this, "Shipment has no trucks or products or delivery place. Remove shipment?", "Empty Shipment", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        newOutbound.Remove();
                        UpdateGrid?.Invoke(this, EventArgs.Empty);
                        Close();
                        return;
                    }
                    return;
                }
                if (newOutbound.TruckQuantityPerShipmentList.Values.Count == 0 || newOutbound.QuantityOfProductList.Values.Count == 0 || newOutbound.DeliveryplaceList.Count == 0)
                {
                    MessageBox.Show(this, "You need to complete truck product and place");
                    return;
                }
            }
            UpdateGrid?.Invoke(this, EventArgs.Empty);
            Close();     
        }
        private void doneButton_Click(object sender, EventArgs e)
        {
            CheckAllThings();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            CheckAllThings();
        }

        //Searching deliveryplace algorithm
        private void deliveryPlaceTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = deliveryPlaceTextBox.Text.ToLower();

            deliveryplaceListBox.Items.Clear();

            foreach(Deliveryplace item in deliveryplaceList)
            {
                if (item.Name.ToLower().Contains(searchText))
                {
                    deliveryplaceListBox.Items.Add(item.Name);
                }
            }
        }

        //Searching product algorithm
        private void productTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = productNameSearchTextBox.Text.ToLower();

            productListBox.Items.Clear();

            foreach (Product item in productList)
            {
                if (item.Name.ToLower().Contains(searchText))
                {
                    productListBox.Items.Add(item.ID);
                }
            }
        }

        //Import Product File Event
        private void importFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                string filePath = openFileDialog.FileName;

                // Read the Excel file and update the DataGridView
                ImportExcelData(filePath);
            }
        }

        private void ImportExcelData(string filePath)
        {
            string item = string.Empty;
            try
            {
                // Create Excel Application
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1];
                range = worksheet.UsedRange;

                //Rethrive data from file to update field algorithm
                for (int row = 2;row <= range.Rows.Count; row++)
                {
                    double kgs = 0;
                    int kgsToQuantity = 0;

                    item = (range.Cells[row, 4] as Excel.Range).Value2?.ToString();
                    product = new Product(item);
                    if(product == null)
                    {
                        MessageBox.Show(this, "Product can't find in Database");
                    }

                    string allocateQty = (range.Cells[row, 7] as Excel.Range).Value2?.ToString();
                    if (double.TryParse(allocateQty, out kgs))
                    {
                        kgsToQuantity = product.GetQuantity(kgs);
                    }
                    else MessageBox.Show(this, "Fail to convert Kgs to Quantity at product :" + item);

                    if (!newOutbound.QuantityOfProductList.ContainsKey(product))
                    {
                        newOutbound.AddProduct(product, kgsToQuantity);
                    }
                    else if (newOutbound.QuantityOfProductList.ContainsKey(product))
                    {
                        newOutbound.ChangeQuantityOfProduct(product, newOutbound.QuantityOfProductList[product] + kgsToQuantity);
                    }
                }
                UpdateProductGridView();
                MessageBox.Show("Data imported successfully.", "Import Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cant Import Part : '{item}'");
                newOutbound.QuantityOfProductList.Clear();
                UpdateProductGridView();
            }
            finally
            {
                // Clean up
                if (range != null) Marshal.ReleaseComObject(range);
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}

﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using Warehouse_IO.Common;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Warehouse_IO.Control;

namespace Warehouse_IO.View.InboundSource
{
    public partial class AddV2 : AddEdit_Inbound_Outbound_FormV2
    {
        Inbound add;
        Inbound newInbound; // After create shipment use this instance to work with truck & product.
        static string connstr = Settings.Default.CONNECTION_STRING;//After create shipment ask shipment ID to Database

        //Variables for update components
        List<SupplierForGetList> supplierList;
        List<TruckForGetList> truckList;
        List<StorageForGetList> storageList;
        List<ProductForDataGridView> productList;

        //Variable for compare selected Index when create shipment
        private List<int> supplierID = new List<int>();
        private List<int> truckID = new List<int>();
        private List<int> storageID = new List<int>();

        //Variable for create selected object on CreateNewShipment()
        Supplier supplier;
        Truck truck;
        Storage storage;
        Product product;
        DateTime deliverydate;

        //Edit quantity pop-Up window components
        EditQuantityWindow editQuantity;
        EditTruckQtyWindow editTruckQty;
        MainForm main;

        //Add product & truck object
        private ProductSource.Add addProduct;
        private Transport.TruckFormSource.Add addTruck;

        //Event to Invoke Update Inbound List
        public event EventHandler UpdateGrid;

        //Variable for Importfile
        Excel.Application excelApp;
        Excel.Workbook workbook;
        Excel.Worksheet worksheet;
        Excel.Range range;

        public AddV2()
        {
            InitializeComponent();
            //Create instance for update components
            supplierList = new List<SupplierForGetList>();
            truckList = new List<TruckForGetList>();
            storageList = new List<StorageForGetList>();
            productList = new List<ProductForDataGridView>();

            //Create instance for edit quantity pop-Up window components
            editQuantity = new EditQuantityWindow();
            editTruckQty = new EditTruckQtyWindow();
            main = new MainForm();

            //Set truck & product gridview auto adjust cell
            truckDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            productListDatagridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //Lock component at truck and product section
            truckGroupBox.Enabled = false;
            productGroupBox.Enabled = false;

            updateComponent();
        }

        private void updateComponent()
        {
            supplierList = SupplierForGetList.GetSupplierList();
            supplierList.Sort((x, y) => x.name.CompareTo(y.name));
            supplierComboBox.Items.Clear();
            foreach (SupplierForGetList supplier in supplierList)
            {
                supplierComboBox.Items.Add(supplier.name);
                supplierID.Add(supplier.ID);
            }

            truckList = TruckForGetList.GetTruckList();
            truckList.Sort((x, y) => x.Description.CompareTo(y.Description));
            truckListBox.Items.Clear();
            foreach (TruckForGetList truck in truckList)
            {
                truckListBox.Items.Add(truck.Name);
                truckID.Add(truck.ID);
            }

            storageList = StorageForGetList.GetStorage();
            storageList.Sort((x, y) => x.Name.CompareTo(y.Name));
            storageLocationComboBox.Items.Clear();
            foreach (StorageForGetList storage in storageList)
            {
                storageLocationComboBox.Items.Add(storage.Name);
                storageID.Add(storage.ID);
            }

            productList = ProductForDataGridView.GetAdjustedProductList();
            productList.Sort((x, y) => x.Name.CompareTo(y.Name));
            productListBox.Items.Clear();
            foreach (ProductForDataGridView product in productList)
            {
                string displayedName = product.Name;
                productListBox.Items.Add(displayedName);
            }
        }

        private void UpdateTruckGridView()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Truck");
            datatable.Columns.Add("Quantity", typeof(int));
            datatable.Columns.Add("ID", typeof(int));
            foreach (KeyValuePair<Truck, int> truckGridlistEntry in newInbound.TruckQuantityPerShipmentList)
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
            foreach (KeyValuePair<Product, int> productGridlistEntry in newInbound.QuantityOfProductList)
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
                    double m3PerUnit = dimension.M3;
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
            if (string.IsNullOrEmpty(invoiceTextBox.Text))
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
            int selectStorageIndex = storageLocationComboBox.SelectedIndex;
            if (selectStorageIndex >= 0 && selectStorageIndex < storageID.Count)
            {
                int selectedStorageID = storageID[selectStorageIndex];
                storage = new Storage(selectedStorageID);
            }
            else
            {
                MessageBox.Show(this, "Please select Storage");
                return;
            }

            add = new Inbound(invoiceTextBox.Text, deliverydate, supplier, storage, IsInterCheckBox.Checked, truckInDetailTextBox.Text,false);

            if (add.Create())
            {
                MySqlConnection conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID() , StorageID FROM inbound WHERE ID = LAST_INSERT_ID()";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int newAddId = Convert.ToInt32(reader["LAST_INSERT_ID()"]);
                            int storageId = Convert.ToInt32(reader["StorageID"]);
                            Storage sto = new Storage(storageId);
                            newInbound = new Inbound(newAddId, sto);
                            MessageBox.Show(this, "Inbound Shipment Created with ID: " + newAddId);
                            shipmentGroupBox.Enabled = false;
                            truckGroupBox.Enabled = true;
                            productGroupBox.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show(this, "Failed to retrieve Inbound ID.");
                        }
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

                    if (!newInbound.TruckQuantityPerShipmentList.ContainsKey(truck))
                    {
                        int quantity = int.Parse(quantityTruckTextBox.Text);
                        newInbound.AddTruck(truck, quantity);
                        quantityTruckTextBox.Text = "";
                        UpdateTruckGridView();
                    }
                    else MessageBox.Show(this, "Same truck is added");
                }
            }
            else MessageBox.Show(this, "Please select truck & put quantity");
        }
        private void addTruckButton_Click(object sender, EventArgs e)
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
                editTruckQty.Owner = main;

                DataGridViewRow selectedRow = truckDataGridView.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                editTruckQty.ShowDialog();

                int newQty = EditTruckQtyWindow.editQty;
                truck = new Truck(id);
                if (newInbound.ChangeQuantityOfTruck(truck, newQty))
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
                int id = 0; // Default value
                object cellValue = selectedRow.Cells["ID"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out id))
                {
                    truck = new Truck(id);
                }
                else
                {
                    MessageBox.Show(this, "No item selected");
                }
                if (newInbound.RemoveTruck(truck))
                {
                    UpdateTruckGridView();
                }
                else MessageBox.Show(this, "Remove Fails");
            }
        }
        private void removeTruckButton_Click(object sender, EventArgs e)
        {
            RemoveTruckFromShipment();
        }
        //Create New Truck
        private void createTruckButton_Click(object sender, EventArgs e)
        {
            addTruck = new Transport.TruckFormSource.Add();
            addTruck.Owner = main;

            addTruck.UpdateGrid += OnUpdateT;
            addTruck.ShowDialog();
        }
        private void OnUpdateT(object sender, EventArgs e)
        {
            updateComponent();
        }

        //Add product to shipment
        private void AddProductToShipment()
        {
            if (productListBox.SelectedIndex >= 0)
            {
                string selectedName = (string)productListBox.SelectedItem;

                    product = new Product(selectedName);
                    if (!newInbound.QuantityOfProductList.ContainsKey(product))
                    {
                        double kgs = double.Parse(productQuantityTextBox.Text);
                        int kgsToQuantity =  product.GetQuantity(kgs);
                        newInbound.AddProduct(product, kgsToQuantity);
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
                if (newInbound.ChangeQuantityOfProduct(product, newQty))
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
                if (newInbound.RemoveProduct(product))
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
        //Create New Product
        private void createProductButton_Click(object sender, EventArgs e)
        {
            addProduct = new ProductSource.Add();
            addProduct.Owner = main;

            addProduct.UpdateGrid += OnUpdateP;
            addProduct.ShowDialog();
        }
        private void OnUpdateP(object sender, EventArgs e)
        {
            updateComponent();
        }

        //Check all are good !!
        private void CheckAllThings()
        {
            if (newInbound != null)
            {
                newInbound.UpdateProduct();
                newInbound.UpdateTruck();
                if (newInbound.TruckQuantityPerShipmentList.Values.Count == 0 && newInbound.QuantityOfProductList.Values.Count == 0)
                {
                    if (MessageBox.Show(this, "Shipment has no trucks or products. Remove shipment?", "Empty Shipment", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        newInbound.Remove();
                        UpdateGrid?.Invoke(this, EventArgs.Empty);
                        Close();
                        return;
                    }
                    return;
                }
               if(newInbound.TruckQuantityPerShipmentList.Values.Count == 0 || newInbound.QuantityOfProductList.Values.Count == 0)
                {
                    MessageBox.Show(this, "You need to complete truck and product");
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

        //Searching product algorithm
        private void productNameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = productNameSearchTextBox.Text.ToLower();

            productListBox.Items.Clear();

            foreach(ProductForDataGridView item in productList)
            {
                if (item.Name.ToLower().Contains(searchText))
                {
                    productListBox.Items.Add(item.Name);
                }
            }
        }

        //Import Product File Event
        private void importButton_Click(object sender, EventArgs e)
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
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    double kgs = 0;
                    int kgsToQuantity = 0;

                    item = (range.Cells[row, 3] as Excel.Range).Value2?.ToString();
                    product = new Product(item);
                    if (product == null)
                    {
                        MessageBox.Show(this, "Product can't find in Database");
                    }

                    string allocateQty = (range.Cells[row, 10] as Excel.Range).Value2?.ToString();
                    if (double.TryParse(allocateQty, out kgs))
                    {
                        kgsToQuantity = product.GetQuantity(kgs);
                    }
                    else MessageBox.Show(this, "Fail to convert Kgs to Quantity at product :" + item);

                    if (!newInbound.QuantityOfProductList.ContainsKey(product))
                    {
                        newInbound.AddProduct(product, kgsToQuantity);
                    }
                    else if (newInbound.QuantityOfProductList.ContainsKey(product))
                    {
                        newInbound.ChangeQuantityOfProduct(product, newInbound.QuantityOfProductList[product] + kgsToQuantity);
                    }
                }
                UpdateProductGridView();
                MessageBox.Show("Data imported successfully.", "Import Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cant Import Part : '{item}'");
                newInbound.QuantityOfProductList.Clear();
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

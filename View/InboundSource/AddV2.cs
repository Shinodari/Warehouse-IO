using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.InboundSource
{
    public partial class AddV2 : AddEdit_Inbound_Outbound_FormV2
    {
        Inbound add;
        Inbound newInbound; // After create shipment use this instance to work with truck & product.
        static string connstr = Settings.Default.CONNECTION_STRING;//After create shipment ask shipment ID to Database

        //Variables for update components
        List<Supplier> supplierList;
        List<Truck> truckList;
        List<Storage> storageList;
        List<Product> productList;

        //Variable for compare selected Index when create shipment
        private List<int> supplierID = new List<int>();
        private List<int> truckID = new List<int>();
        private List<int> storageID = new List<int>();
        private List<int> productID = new List<int>();

        //Variable for create selected object on CreateNewShipment()
        Supplier supplier;
        Truck truck;
        Storage storage;
        Product product;
        DateTime deliverydate;

        //Edit quantity pop-Up window components
        EditQuantityWindow editQuantity;
        MainForm main;

        //Event to Invoke Update Inbound List
        public event EventHandler UpdateGrid;

        public AddV2()
        {
            InitializeComponent();
            //Create instance for update components
            supplierList = new List<Supplier>();
            truckList = new List<Truck>();
            storageList = new List<Storage>();
            productList = new List<Product>();

            //Create instance for edit quantity pop-Up window components
            editQuantity = new EditQuantityWindow();
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
            supplierList = Supplier.GetSupplierList();
            supplierList.Sort((x, y) => x.Name.CompareTo(y.Name));
            supplierComboBox.Items.Clear();
            foreach (Supplier supplier in supplierList)
            {
                supplierComboBox.Items.Add(supplier.Name);
                supplierID.Add(supplier.ID);
            }

            truckList = Truck.GetTruckList();
            truckList.Sort((x, y) => x.Name.CompareTo(y.Name));
            truckListBox.Items.Clear();
            foreach (Truck truck in truckList)
            {
                truckListBox.Items.Add(truck.Name);
                truckID.Add(truck.ID);
            }

            storageList = Storage.GetStorage();
            storageList.Sort((x, y) => x.Name.CompareTo(y.Name));
            storageLocationComboBox.Items.Clear();
            foreach (Storage storage in storageList)
            {
                storageLocationComboBox.Items.Add(storage.Name);
                storageID.Add(storage.ID);
            }

            productList = Product.GetProductList();
            productList.Sort((x, y) => x.Name.CompareTo(y.Name));
            productListBox.Items.Clear();
            foreach (Product product in productList)
            {
                productListBox.Items.Add(product.Name);
                productID.Add(product.ID);
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
            datatable.Columns.Add("ID", typeof(int));
            foreach (KeyValuePair<Product, int> productGridlistEntry in newInbound.QuantityOfProductList)
            {
                Product product = productGridlistEntry.Key;
                int quantity = productGridlistEntry.Value;
                DataRow row = datatable.NewRow();
                row["Name"] = product.Name;
                row["Quantity"] = quantity;
                row["ID"] = product.ID;
                datatable.Rows.Add(row);
            }
            datatable.DefaultView.Sort = "Name ASC";
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

            add = new Inbound(invoiceTextBox.Text, deliverydate, supplier, storage);

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
                editQuantity.Owner = main;

                DataGridViewRow selectedRow = truckDataGridView.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells[2].Value);

                editQuantity.ShowDialog();

                int newQty = EditQuantityWindow.editQty;
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
                int id = Convert.ToInt32(selectedRow.Cells[2].Value);
                truck = new WHIO.Model.Truck(id);
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

        //Add product to shipment
        private void AddProductToShipment()
        {
            if (productListBox.SelectedItem != null)
            {
                int selectedProductIndex = productListBox.SelectedIndex;
                if (selectedProductIndex >= 0 && selectedProductIndex < productID.Count)
                {
                    int selectedProductID = productID[selectedProductIndex];
                    product = new WHIO.Model.Product(selectedProductID);

                    if (!newInbound.QuantityOfProductList.ContainsKey(product))
                    {
                        int quantity = int.Parse(productQuantityTextBox.Text);
                        newInbound.AddProduct(product, quantity);
                        productQuantityTextBox.Text = "";
                        UpdateProductGridView();
                    }
                    else MessageBox.Show(this, "Same product is added");
                }
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

                DataGridViewRow selectedRow = productListDatagridView.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells[2].Value);

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
                int id = Convert.ToInt32(selectedRow.Cells[2].Value);
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
    }
}

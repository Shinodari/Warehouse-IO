﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.InboundSource
{
    public partial class EditV2 : AddEdit_Inbound_Outbound_FormV2
    {
        Inbound edit;

        //Variables for update components
        List<Supplier> supplierList;
        List<Truck> truckList;
        List<Storage> storageList;
        List<Product> productList;

        //Variable for compare selected Index when edit shipment
        private List<int> supplierID = new List<int>();
        private List<int> truckID = new List<int>();
        private List<Truck> selectedTruck = new List<Truck>();
        private List<int> storageID = new List<int>();
        private List<int> productID = new List<int>();

        //Variable to to compare if it's changed
        string inv;

        //Variable for create selected object on EditShipment()
        Supplier supplier;
        Truck truck;
        Storage storage;
        Product product;

        //Edit quantity pop-Up window components
        EditQuantityWindow editQuantity;
        MainForm main;

        //Event to Invoke Update Inbound List
        public event EventHandler UpdateGrid;

        public EditV2()
        {
            InitializeComponent();

            //Create selected Instance from InboundFrom
            storage = new Storage(Global.tempStorageKey);
            edit = new Inbound(Global.tempPkey, storage);
            //Duplicate inv TextBox for compare at Done & Close
            inv = edit.InvoiceNo;

            //Populate current property of Instance
            supplierComboBox.Text = edit.Supplier.Name;
            invoiceTextBox.Text = edit.InvoiceNo;
            deliveryDatedateTimePicker.Value = edit.DeliveryDate;
            storageLocationComboBox.Text = edit.Storage.Name;
            IsInterCheckBox.Checked = edit.Inter;
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

            updateComponent();
            UpdateTruckGridView();
            UpdateProductGridView();
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
            foreach (KeyValuePair<Truck, int> truckGridlistEntry in edit.TruckQuantityPerShipmentList)
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
            foreach (KeyValuePair<Product, int> productGridlistEntry in edit.QuantityOfProductList)
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

        //Edit Shipment
        private bool EditShipment()
        {
            bool isSuccess = true;
            if(edit.Supplier.Name != (supplierComboBox.SelectedItem as Supplier)?.Name)
            {
                int selectedSupplierIndex = supplierComboBox.SelectedIndex;
                if (selectedSupplierIndex >= 0 && selectedSupplierIndex < supplierID.Count)
                {
                    int selectedSuppierID = supplierID[selectedSupplierIndex];
                    supplier = new Supplier(selectedSuppierID);
                    edit.Supplier = supplier;
                    MessageBox.Show(this, "Supplier Edited");
                }
            }
            if (!string.IsNullOrWhiteSpace(inv))
            {
                if (inv != edit.InvoiceNo)
                {
                    edit.InvoiceNo = inv;
                    MessageBox.Show(this, "Invoice Edited");
                }
            }
            else
            {
                MessageBox.Show(this, "Invoice can't be blank");
                isSuccess = false;
            }

            if (edit.DeliveryDate != deliveryDatedateTimePicker.Value)
            {
                edit.DeliveryDate = deliveryDatedateTimePicker.Value;
                MessageBox.Show(this, "Delivery date Edited");
            }
            if(edit.Storage.Name != (storageLocationComboBox.SelectedItem as Storage)?.Name)
            {
                int selectedStorageIndex = storageLocationComboBox.SelectedIndex;
                if(selectedStorageIndex >= 0 && selectedStorageIndex < storageID.Count)
                {
                    int selectedStorageID = storageID[selectedStorageIndex];
                    storage = new Storage(selectedStorageID);
                    edit.Storage = storage;
                    MessageBox.Show(this, "Storage Edited");
                }
            }
            if(edit.Inter != IsInterCheckBox.Checked)
            {
                edit.Inter = IsInterCheckBox.Checked;
                if(edit.Inter == true)
                {
                    MessageBox.Show(this, "Change status to Import");
                }
                else MessageBox.Show(this, "Change status to Domestic");
            }
            return isSuccess;
        }
        private void createShipmentButton_Click(object sender, EventArgs e)
        {
            inv = invoiceTextBox.Text;
            EditShipment();
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

                    if (!edit.TruckQuantityPerShipmentList.ContainsKey(truck))
                    {
                        int quantity = int.Parse(quantityTruckTextBox.Text);
                        edit.AddTruck(truck, quantity);
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
                if (edit.ChangeQuantityOfTruck(truck, newQty))
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
                if (edit.RemoveTruck(truck))
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

                    if (!edit.QuantityOfProductList.ContainsKey(product))
                    {
                        int quantity = int.Parse(productQuantityTextBox.Text);
                        edit.AddProduct(product, quantity);
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
                if (edit.ChangeQuantityOfProduct(product, newQty))
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
                if (edit.RemoveProduct(product))
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

        //Check all are good before done!!
        private bool CheckAllThings()
        {
            bool isSuccess = true;
            inv = invoiceTextBox.Text;
            edit.UpdateTruck();
            edit.UpdateProduct();
            if (EditShipment())
            {
                if (!edit.Change())
                {
                    MessageBox.Show(this,"Can't update shipment in database");
                    isSuccess = false;
                }
            }
            else isSuccess = false;
            if (edit.TruckQuantityPerShipmentList.Values.Count == 0 && edit.QuantityOfProductList.Values.Count == 0)
            {
                if (MessageBox.Show(this, "Shipment has no truck and product. Remove shipment?", "Empty Shipment", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    edit.Remove();
                }
                else isSuccess = false;
            }
            else if (edit.TruckQuantityPerShipmentList.Values.Count == 0 || edit.QuantityOfProductList.Values.Count == 0)
            {
                MessageBox.Show(this, "You need to complete truck and product");
                isSuccess = false;
            }
            return isSuccess;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if (CheckAllThings())
            {
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            return;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (CheckAllThings())
            {
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            return;
        }
    }
}
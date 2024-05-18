using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View.DeliveryplaceSource;
using Warehouse_IO.View.StorageFormSource;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.DepartmentFormSource
{
    public partial class departmentAddStorage_Deliveryplace : Form
    {
        Department department;
        Storage storage;
        Deliveryplace deliveryplace;

        //Variable for update components
        List<StorageForGetList> storagelist;
        List<DeliveryplaceForGetList> deliveryplacelist;

        //Variable for compare selected Index in Listbox (No search)
        private List<int> storageID = new List<int>();
        private List<int> deliveryplaceID = new List<int>();

        //Variable for compare selected Index in Listbox (With search)
        private readonly Dictionary<string, DeliveryplaceForGetList> deliveryplaceNameToDeliveryplace = new Dictionary<string, DeliveryplaceForGetList>();

        MainForm main;

        //Event to Invoke Update department gridview
        public event EventHandler UpdateGrid;
        public departmentAddStorage_Deliveryplace()
        {
            InitializeComponent();
            department = new Department(Global.tempPkey);
            //Create instance for update components
            storagelist = new List<StorageForGetList>();
            deliveryplacelist = new List<DeliveryplaceForGetList>();

            main = new MainForm();

            //Set storage & deliveryplace gridview auto adjust cell
            DeliveryplaceGridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            storageGridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            updateComponent();
            UpdateStorageGridView();
            UpdateDeliveryplaceGridView();
        }

        private void updateComponent()
        {
            storagelist = Storage.GetStorage();
            storagelist.Sort((x, y) => x.Name.CompareTo(y.Name));
            storageListBox.Items.Clear();
            foreach(StorageForGetList sto in storagelist)
            {
                string displayedName = sto.Name;
                storageListBox.Items.Add(displayedName);
                storageID.Add(sto.ID);
            }

            deliveryplacelist = Deliveryplace.GetDeliveryplaceList();
            deliveryplacelist.Sort((x, y) => x.Name.CompareTo(y.Name));
            deliveryplaceListBox.Items.Clear();
            foreach (DeliveryplaceForGetList delivery in deliveryplacelist)
            {
                string displayedName = delivery.Name;
                deliveryplaceListBox.Items.Add(displayedName);

                deliveryplaceNameToDeliveryplace[displayedName] = delivery;
            }
        }

        private void UpdateStorageGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID",typeof(int));
            dataTable.Columns.Add("Name");
            foreach(Storage storageEntry in department.StorageList)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = storageEntry.ID;
                row["Name"] = storageEntry.Name;
                dataTable.Rows.Add(row);
            }
            dataTable.DefaultView.Sort = "Name DESC";
            storageGridview.DataSource = dataTable.DefaultView;
        }
        private void UpdateDeliveryplaceGridView()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Name");
            datatable.Columns.Add("ID", typeof(int));
            foreach (Deliveryplace deliveryplace in department.DeliveryplaceList)
            {
                DataRow row = datatable.NewRow();
                row["Name"] = deliveryplace.Name;
                row["ID"] = deliveryplace.ID;
                datatable.Rows.Add(row);
            }
            datatable.DefaultView.Sort = "Name ASC";
            DeliveryplaceGridview.DataSource = datatable.DefaultView;
        }

        //Add storage to department
        private void AddStorageToDepartment()
        {
            if(storageListBox.SelectedItem != null)
            {
                int selectedStorageIndex = storageListBox.SelectedIndex;
                if(selectedStorageIndex>=0 && selectedStorageIndex < storageID.Count)
                {
                    int selectedStorageID = storageID[selectedStorageIndex];
                    storage = new Storage(selectedStorageID);

                    if (!department.StorageList.Contains(storage))
                    {
                        department.AddStorage(storage);
                        UpdateStorageGridView();
                    }
                    else MessageBox.Show(this, "Same storage is added");
                }
            }
        }
        private void addStorageButton_Click(object sender, EventArgs e)
        {
            AddStorageToDepartment();
        }
        private void storageListBox_DoubleClick(object sender, EventArgs e)
        {
            AddStorageToDepartment();
        }

        //Remove storage form department
        private void RemoveStorageFromDepartment()
        {
            if(storageGridview.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = storageGridview.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                storage = new Storage(id);
                if (department.RemoveStorage(storage))
                {
                    UpdateStorageGridView();
                }
                else MessageBox.Show(this, "Remove Fails");
            }
        }
        private void removeStorageButton_Click(object sender, EventArgs e)
        {
            RemoveStorageFromDepartment();
        }
        private void storageGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveStorageFromDepartment();
        }

        //Add deliveryplace to department
        private void AddDeliveryplaceToDepartment()
        {
            if (deliveryplaceListBox.SelectedIndex >= 0)
            {
                string selectedName = (string)deliveryplaceListBox.SelectedItem;

                if (deliveryplaceNameToDeliveryplace.ContainsKey(selectedName))
                {
                    DeliveryplaceForGetList selectedDeliveryplace = deliveryplaceNameToDeliveryplace[selectedName];
                    int selectedDeliveryplaceID = selectedDeliveryplace.ID;

                    deliveryplace = new Deliveryplace(selectedDeliveryplaceID);
                    department.AddDeliveryplace(deliveryplace);
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
        private void addDeliveryplaceButton_Click(object sender, EventArgs e)
        {
            AddDeliveryplaceToDepartment();
        }
        private void deliveryplaceListBox_DoubleClick(object sender, EventArgs e)
        {
            AddDeliveryplaceToDepartment();
        }
        private void deliveryplaceListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddDeliveryplaceToDepartment();
            }
        }

        //Remove deliveryplace from department
        private void RemoveDeliveryplaceFromDepartment()
        {
            if(DeliveryplaceGridview.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DeliveryplaceGridview.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                deliveryplace = new Deliveryplace(id);
                if (department.RemoveDeliveryplace(deliveryplace))
                {
                    UpdateDeliveryplaceGridView();
                }
                else MessageBox.Show(this, "Remove Fails");
            }
        }
        private void removeDeliveryplaceButton_Click(object sender, EventArgs e)
        {
            RemoveDeliveryplaceFromDepartment();
        }
        private void DeliveryplaceGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveDeliveryplaceFromDepartment();
        }

        //Update Storage and Deliveryplace
        private bool UpdateProductAndDeliveryplaceToDepartment()
        {
            bool isSuccess = true;
            if (department.UpdateDeliveryplace())
            {
                MessageBox.Show(this, "Updated Deliveryplace to Department");
            }
            else
            {
                MessageBox.Show(this, "Update Deliveryplace Fail");
                isSuccess = false;
            }
            if (department.UpdateStorage())
            {
                MessageBox.Show(this, "Updated Storage to Department");
            }
            else
            {
                MessageBox.Show(this, "Update Storage Fail");
                isSuccess = false;
            }
            return isSuccess;
        }
        private void doneButton_Click(object sender, EventArgs e)
        {
            if (UpdateProductAndDeliveryplaceToDepartment())
            {
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            return;
        }

        //Searching deliveryplace algorithm
        private void deliveryPlaceTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = deliveryPlaceTextBox.Text.ToLower();

            deliveryplaceListBox.Items.Clear();

            foreach (DeliveryplaceForGetList item in deliveryplacelist)
            {
                if (item.Name.ToLower().Contains(searchText))
                {
                    deliveryplaceListBox.Items.Add(item.Name);
                }
            }
        }

        
    }
}

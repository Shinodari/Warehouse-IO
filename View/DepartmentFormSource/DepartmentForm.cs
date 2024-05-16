using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.DepartmentFormSource;
using System.Data;
using System.Text;

namespace Warehouse_IO
{
    public partial class DepartmentForm : Form
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        private departmentAddStorage_Deliveryplace addStorageandDelplace;

        MainForm main;

        List<Department> departmentList;

        public event EventHandler returnMain;

        public DepartmentForm()
        {
            InitializeComponent();
            departmentList = new List<Department>();
            main = new MainForm();

            depGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            UpdateDepDatagridView();
        }
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        public void UpdateDepDatagridView()
        {
            departmentList = Department.GetDepartmentList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Department");
            dataTable.Columns.Add("Storage");

            foreach(Department dep in departmentList)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = dep.ID;
                row["Department"] = dep.Name;

                StringBuilder storageOnDep = new StringBuilder();
                if(dep.StorageList != null)
                {
                    foreach(Storage sto in dep.StorageList)
                    {
                        storageOnDep.Append(sto.Name).Append(" / ");
                    }
                    if (storageOnDep.Length > 0)
                    {
                        storageOnDep.Length -= 2;
                    }
                    row["Storage"] = storageOnDep.ToString();
                }
                dataTable.Rows.Add(row);
            }
            depGridView.DataSource = dataTable.DefaultView;
        }

        private void addDepButton(object sender, EventArgs e)
        {
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }
        private void editDepButton(object sender, EventArgs e)
        {
            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }
        private void removeDepButton(object sender, EventArgs e)
        {
            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.ShowDialog();
        }
        private void addStorage_DelplaceButton_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = depGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;

            Global.tempPkey = value;

            addStorageandDelplace = new departmentAddStorage_Deliveryplace();
            addStorageandDelplace.Owner = main;

            addStorageandDelplace.UpdateGrid += OnUpdate;
            addStorageandDelplace.ShowDialog();
        }

        private void exitDepButton(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateDepDatagridView();
        }
    }
}

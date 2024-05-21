using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;

namespace Warehouse_IO.View.UOMSource
{
    public partial class UOMForm : ParentForm
    {
        private AddUOM add;
        private EditUOM edit;
        private Remove remove;
        MainForm main;

        List<UOMForGetList> list;
        BindingSource bind = new BindingSource();
        public event EventHandler returnMain;

        public UOMForm()
        {
            InitializeComponent();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            list = new List<UOMForGetList>();
            UpdateDatagridView();
            main = new MainForm();
        }

        private void UOMForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            list = UOM.GetUOMList();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID",typeof(int));
            dataTable.Columns.Add("Quantity",typeof(double));
            dataTable.Columns.Add("Unit");
            dataTable.Columns.Add("Package");
            dataTable.Columns.Add("Description");

            foreach (UOMForGetList uom in list)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = uom.ID;
                row["Quantity"] = uom.Quantity;
                row["Unit"] = uom.Unit;
                row["Package"] = uom.Package;
                row["Description"] = uom.Details;

                dataTable.Rows.Add(row);
            }
            dataTable.DefaultView.Sort = "Quantity ASC";
            dataGridView.DataSource = dataTable.DefaultView;
        }
        
        private void a_Click(object sender, EventArgs e)
        {
            add = new AddUOM();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }
        private void e_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells["ID"].Value;
            Global.tempPkey = value;

            edit = new EditUOM();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }
        private void r_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells["ID"].Value;
            Global.tempPkey = value;

            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.ShowDialog();
        }
        private void x_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateDatagridView();
        }
    }
}

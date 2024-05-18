using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;

namespace Warehouse_IO.View.Dimensions.DimensionSource
{
    public partial class DimensionsForm : ParentForm
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList> list;
        BindingSource bind = new BindingSource();
        public event EventHandler returnMain;

        public DimensionsForm()
        {
            InitializeComponent();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            list = new List<Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList>();
            UpdateDatagridView();
            main = new MainForm();
        }

        private void DimensionsForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            list = Warehouse_IO.WHIO.Model.Dimension.GetDimensionList();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("M3", typeof(double));
            dataTable.Columns.Add("Unit");
            dataTable.Columns.Add("Width", typeof(double));
            dataTable.Columns.Add("Length", typeof(double));
            dataTable.Columns.Add("Height", typeof(double));
            dataTable.Columns.Add("Description");

            foreach (Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList dimension in list)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = dimension.ID;
                row["M3"] = dimension.M3;
                row["Unit"] = dimension.UnitOfVolume;
                row["Width"] = dimension.Width;
                row["Length"] = dimension.Length;
                row["Height"] = dimension.Height;
                row["Description"] = dimension.Details;

                dataTable.Rows.Add(row);
            }
            dataGridView.DataSource = dataTable.DefaultView;
        }

        private void a_Click(object sender, EventArgs e)
        {
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }
        private void e_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;
            Global.tempPkey = value;

            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }
        private void r_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;
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

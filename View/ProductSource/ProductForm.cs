using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;

namespace Warehouse_IO.View.ProductSource
{
    public partial class ProductForm : ParentForm
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<Product> productList;
        UOM uom;
        Warehouse_IO.WHIO.Model.Dimension dimension;
        BindingSource bind = new BindingSource();
        public event EventHandler returnMain;

        public ProductForm()
        {
            InitializeComponent();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            productList = new List<Product>();
            UpdateDatagridView();
            main = new MainForm();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            productList = Product.GetProductList();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Details");
            dataTable.Columns.Add("M3",typeof(double));
            dataTable.Columns.Add("Weight",typeof(double));
            dataTable.Columns.Add("Unit");
            dataTable.Columns.Add("Package");

            foreach (Product product in productList)
            {
                DataRow row = dataTable.NewRow();
                row["Name"] = product.ID;
                row["Details"] = product.Name ;
                row["M3"] = product.Dimension.GetM3();
                row["Weight"] = product.UOM.Quantity;
                row["Unit"] = product.UOM.Unit.Name;
                row["Package"] = product.UOM.Package.Name;

                dataTable.Rows.Add(row);
            }
            dataTable.DefaultView.Sort = "Name ASC";
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
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            Global.tempPkeyName = null;
            string id = (string)selectedRow.Cells["Name"].Value;
            Global.tempPkeyName = id;

            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }
        private void r_Click(object sender, EventArgs e)
        {
            Global.tempPkeyName = null;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            string id = (string)selectedRow.Cells["Name"].Value;
            Global.tempPkeyName = id;

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

        private void searchProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = searchProductNameTextBox.Text;
            (dataGridView.DataSource as DataView).RowFilter = $"Name LIKE '%{filterText}%' OR Details LIKE '%{filterText}%'";
        }
    }
}

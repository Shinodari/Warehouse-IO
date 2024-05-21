using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;
using System.Linq;
using Warehouse_IO.Control;

namespace Warehouse_IO.View.ProductSource
{
    public partial class ProductForm : ParentForm
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<ProductForDataGridView> productfordatagridview;
        List<ProductForDataGridView> listforsearch;

        BindingSource bindingSource;

        public event EventHandler returnMain;

        public ProductForm()
        {
            InitializeComponent();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            main = new MainForm();
            productfordatagridview = new List<ProductForDataGridView>();
            bindingSource = new BindingSource();

            UpdateDatagridView();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            productfordatagridview = ProductForDataGridView.GetAdjustedProductList();

            bindingSource.DataSource = productfordatagridview;
            dataGridView.DataSource = bindingSource;
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
            string filterText = searchProductNameTextBox.Text.ToLower();
            listforsearch = productfordatagridview.Where(p => p.Details.ToLower().Contains(filterText)).ToList();

            UpdateFilterProduct();
        }
        public void UpdateFilterProduct()
        {
            bindingSource.DataSource = listforsearch;
            dataGridView.DataSource = bindingSource;
        }
    }
}

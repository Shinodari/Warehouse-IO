using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;

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
            bind.DataSource = productList;
            productList.Sort((x, y) => x.Name.CompareTo(y.Name));
            dataGridView.DataSource = bind;

            dataGridView.CellFormatting += DataGridView_CellFormatting;
        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (dataGridView.Rows[e.RowIndex].DataBoundItem != null)
                {
                    Product data = (Product)dataGridView.Rows[e.RowIndex].DataBoundItem;
                    uom = new UOM(data.UOM.ID);
                    dimension = new WHIO.Model.Dimension(data.Dimension.ID);
                    if (e.ColumnIndex == 2)
                    {
                        string formattedValue = $"{uom.Quantity}{uom.Unit.Name}/{uom.Package.Name} {uom.Name}";
                        e.Value = formattedValue;
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        string formattedValue = $"{dimension.Width} x {dimension.Length} x {dimension.Height} {dimension.Unit.Name} {dimension.Name}";
                        e.Value = formattedValue;
                    }
                }
            }
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
            Global.tempPkey = -1;
            int value = (int)selectedRow.Cells[0].Value;
            Global.tempPkey = value;

            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }
        private void r_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            Global.tempPkey = -1;
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

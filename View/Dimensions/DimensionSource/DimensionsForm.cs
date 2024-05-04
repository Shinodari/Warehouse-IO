using System;
using System.Collections.Generic;
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

        List<Warehouse_IO.WHIO.Model.Dimension> list;
        BindingSource bind = new BindingSource();
        public event EventHandler returnMain;

        public DimensionsForm()
        {
            InitializeComponent();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            list = new List<Warehouse_IO.WHIO.Model.Dimension>();
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
            bind.DataSource = list;
            list.Sort((x, y) => x.ID.CompareTo(y.ID));
            dataGridView.DataSource = bind;

            dataGridView.CellFormatting += DataGridView_CellFormatting;
        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (dataGridView.Rows[e.RowIndex].DataBoundItem != null)
                {
                    Warehouse_IO.WHIO.Model.Dimension uom = (Warehouse_IO.WHIO.Model.Dimension)dataGridView.Rows[e.RowIndex].DataBoundItem;

                    if (e.ColumnIndex == 5)
                    {
                        e.Value = uom.Unit.Name;
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

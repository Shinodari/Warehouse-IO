using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;

namespace Warehouse_IO.View.UOMSource
{
    public partial class UOMForm : ParentForm
    {
        private AddUOM add;
        private EditUOM edit;
        private Remove remove;
        MainForm main;

        List<UOM> list;
        BindingSource bind = new BindingSource();
        public event EventHandler returnMain;

        public UOMForm()
        {
            InitializeComponent();
            list = new List<UOM>();
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
            bind.DataSource = list;
            list.Sort((x, y) => x.ID.CompareTo(y.ID));
            dataGridView.DataSource = bind;

            dataGridView.CellFormatting += DataGridView_CellFormatting;
        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (dataGridView.Rows[e.RowIndex].DataBoundItem != null)
                {
                    UOM uom = (UOM)dataGridView.Rows[e.RowIndex].DataBoundItem;

                    if (e.ColumnIndex == 2)
                    {
                        e.Value = uom.Package.Name;
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        e.Value = uom.Unit.Name;
                    }
                }
            }
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
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;
            Global.tempPkey = value;

            edit = new EditUOM();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }
        private void r_Click(object sender, EventArgs e)
        {
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

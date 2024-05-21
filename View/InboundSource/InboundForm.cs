using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;
using Warehouse_IO.Control;
using System.Linq;

namespace Warehouse_IO.View.InboundSource
{
    public partial class InboundForm : ParentForm
    {
        private AddV2 add;
        private EditV2 edit;
        private Remove remove;

        MainForm main;

        BindingSource bindingSource;
        List<InboundActivity> inboundlist;
        List<InboundActivity> listforsearch;

        public event EventHandler returnMain;

        public InboundForm()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            inboundlist = new List<InboundActivity>();
            main = new MainForm();

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateDatagridView();
        }

        private void InboundForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        public void UpdateDatagridView()
        {
            inboundlist = InboundActivity.GetInboundList();

            bindingSource.DataSource = inboundlist;
            dataGridView.DataSource = bindingSource;

            if (dataGridView.Columns["StorageID"] != null)
            {
                dataGridView.Columns["StorageID"].Visible = false;
            }
            if (dataGridView.Columns["InboundID"] != null)
            {
                dataGridView.Columns["InboundID"].Visible = false;
            }
            if (dataGridView.Columns["M3"] != null)
            {
                dataGridView.Columns["M3"].Visible = false;
            }
            if (dataGridView.Columns["Date"] != null)
            {
                dataGridView.Columns["Date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }
        }

        private void a_Click(object sender, EventArgs e)
        {
            add = new InboundSource.AddV2();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }

        private void e_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            Global.tempStorageKey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells["InboundID"].Value;
            int storageKey = (int)selectedRow.Cells["StorageID"].Value;

            Global.tempStorageKey = storageKey;
            Global.tempPkey = value;

            edit = new EditV2();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void r_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            Global.tempStorageKey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells["InboundID"].Value;
            int storageKey = (int)selectedRow.Cells["StorageID"].Value;

            Global.tempStorageKey = storageKey;
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

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = searchTextBox.Text.ToLower();
            listforsearch = inboundlist.Where(i => i.Invoice.ToLower().Contains(filterText)
            || i.Customer.ToLower().Contains(filterText)).ToList();

            updateSearchdataGridView();
        }
        public void updateSearchdataGridView()
        {
            bindingSource.DataSource = listforsearch;
            dataGridView.DataSource = bindingSource;
        }
    }
}

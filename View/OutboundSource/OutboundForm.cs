using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;
using System.Linq;
using Warehouse_IO.View.In_Out_ActivityForm;

namespace Warehouse_IO.View.OutboundSource
{
    public partial class OutboundForm : ParentForm
    {
        private Add add;
        private Edit edit;
        private Remove remove;

        MainForm main;

        BindingSource bindingSource;
        List<OutboundActivity> outboundlist;
        List<OutboundActivity> listforsearch;

        public event EventHandler returnMain;

        public OutboundForm()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            outboundlist = new List<OutboundActivity>();
            main = new MainForm();

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateDatagridView();
        }

        private void OutboundForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        public void UpdateDatagridView()
        {
            outboundlist = Outbound.GetOutboundList();

            bindingSource.DataSource = outboundlist;
            dataGridView.DataSource = bindingSource;

            if (dataGridView.Columns["OutboundID"] != null)
            {
                dataGridView.Columns["OutboundID"].Visible = false;
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
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }

        private void e_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[7].Value;
            Global.tempPkey = value;

            edit = new OutboundSource.Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void r_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[7].Value;
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
            listforsearch = outboundlist.Where(i => i.Invoice.ToLower().Contains(filterText)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public partial class InOutActivityForm : Form
    {

        private InboundItemForm inboundItemlist;
        private OutboundItemForm outboundItemlist;

        BindingSource inbindingSource;
        BindingSource outbindingSource;

        List<InboundActivity> inboundactivitylist;
        List<OutboundActivity> outboundactivitylist;

        MainForm main;

        public event EventHandler returnMain;

        public InOutActivityForm()
        {
            InitializeComponent();
            inbindingSource = new BindingSource();
            outbindingSource = new BindingSource();
            inboundactivitylist = new List<InboundActivity>();
            outboundactivitylist = new List<OutboundActivity>();

            inboundDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            outboundDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            UpdateInboundDatagridView();
            UpdateOutboundDatagridView();
        }

        private void InOutActivityForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

        public void UpdateInboundDatagridView()
        {
            inboundactivitylist = Inbound.GetInboundList();

            inbindingSource.DataSource = inboundactivitylist;
            inboundDataGridView.DataSource = inbindingSource;

            if (inboundDataGridView.Columns["StorageID"] != null)
            {
                inboundDataGridView.Columns["StorageID"].Visible = false;
            }
            if (inboundDataGridView.Columns["InboundID"] != null)
            {
                inboundDataGridView.Columns["InboundID"].Visible = false;
            }
            if (inboundDataGridView.Columns["Date"] != null)
            {
                inboundDataGridView.Columns["Date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }
        }

        public void UpdateOutboundDatagridView()
        {
            outboundactivitylist = Outbound.GetOutboundList();

            outbindingSource.DataSource = outboundactivitylist;
            outboundDataGridView.DataSource = outbindingSource;

            if (outboundDataGridView.Columns["OutboundID"] != null)
            {
                outboundDataGridView.Columns["OutboundID"].Visible = false;
            }
            if (outboundDataGridView.Columns["Date"] != null)
            {
                outboundDataGridView.Columns["Date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }

        }

        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateInboundDatagridView();
        }

        private void inboundDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.tempPkey = -1;
            Global.tempStorageKey = -1;
            DataGridViewRow selectedRow = inboundDataGridView.CurrentRow;
            int value = (int)selectedRow.Cells["InboundID"].Value;
            int storageKey = (int)selectedRow.Cells["StorageID"].Value;

            Global.tempStorageKey = storageKey;
            Global.tempPkey = value;

            inboundItemlist = new InboundItemForm();
            inboundItemlist.Owner = main;

            inboundItemlist.ShowDialog();
        }

        private void outboundDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = outboundDataGridView.CurrentRow;
            int value = (int)selectedRow.Cells["OutboundID"].Value;

            Global.tempPkey = value;

            outboundItemlist = new OutboundItemForm();
            outboundItemlist.Owner = main;

            outboundItemlist.ShowDialog();
        }
    }
}

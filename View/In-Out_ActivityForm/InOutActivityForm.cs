using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public partial class InOutActivityForm : Form
    {

        private InboundItemForm inboundItemlist;
        private OutboundItemForm outboundItemlist;
        private DateTimePickerForm datepickform;

        BindingSource inbindingSource;
        BindingSource outbindingSource;

        List<InboundActivity> inboundactivitylist;
        List<OutboundActivity> outboundactivitylist;
        // For reset Index at KeyUp
        private int previousRowIndex = -1;

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
            //Event subscribe for Inbound complete check
            inboundDataGridView.KeyDown += inboundDataGridView_KeyDown;
            inboundDataGridView.KeyUp += inboundDataGridView_KeyUp;
            inboundDataGridView.CellFormatting += inboundDataGridView_CellFormatting;
            //Event subscribe for Outbound complete check
            outboundDataGridView.KeyDown += outboundDataGridView_KeyDown;
            outboundDataGridView.KeyUp += outboundDataGridView_KeyUp;
            outboundDataGridView.CellFormatting += outboundDataGridView_CellFormatting;

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
            if (inboundDataGridView.Columns["M3"] != null)
            {
                inboundDataGridView.Columns["M3"].Visible = false;
            }
            if (inboundDataGridView.Columns["IsComplete"] != null)
            {
                inboundDataGridView.Columns["IsComplete"].Visible = false;
            }
            if (inboundDataGridView.Columns["Date"] != null)
            {
                inboundDataGridView.Columns["Date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }
        }
        //Row color's setting for IsComplete
        private void inboundDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = inboundDataGridView.Rows[e.RowIndex];
                InboundActivity inb = row.DataBoundItem as InboundActivity;
                if (inb.Iscomplete)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = inboundDataGridView.DefaultCellStyle.BackColor;
                }
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
            if (outboundDataGridView.Columns["M3"] != null)
            {
                outboundDataGridView.Columns["M3"].Visible = false;
            }
            if (outboundDataGridView.Columns["Date"] != null)
            {
                outboundDataGridView.Columns["Date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }
        }
        //Row color's setting for IsComplete
        private void outboundDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = outboundDataGridView.Rows[e.RowIndex];
                OutboundActivity oub = row.DataBoundItem as OutboundActivity;
                if (oub.Iscomplete)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = outboundDataGridView.DefaultCellStyle.BackColor;
                }
            }
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateInboundDatagridView();
        }
        //Check Item list
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

        private void createReportButton_Click(object sender, EventArgs e)
        {
            datepickform = new DateTimePickerForm();
            datepickform.Owner = main;

            datepickform.ShowDialog();
        }
        //Process for check / update DB and change color Inbound
        private void ProcessInbCurrentRow(DataGridViewRow currentRow)
        {
            if (currentRow == null)
            {
                return;
            }
            InboundActivity obj = currentRow.DataBoundItem as InboundActivity;
            if (obj == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Complete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            obj.Iscomplete = !obj.Iscomplete;
            currentRow.DefaultCellStyle.BackColor = obj.Iscomplete ? Color.LightSeaGreen : inboundDataGridView.DefaultCellStyle.BackColor;

            Storage sto = new Storage(obj.StorageID);
            Inbound inbound = new Inbound(obj.InboundID, sto);
            inbound.IsComplete = obj.Iscomplete;
            inbound.Change();
        }
        private void inboundDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && previousRowIndex != -1)
            {
                DataGridViewRow previousRow = inboundDataGridView.Rows[previousRowIndex];
                ProcessInbCurrentRow(previousRow);
                previousRowIndex = -1;
                e.Handled = true;
            }
        }
        private void inboundDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                previousRowIndex = inboundDataGridView.CurrentCell.RowIndex;
            }
        }
        //Process for check / update DB and change color Outbound
        private void ProcessOubCurrentRow(DataGridViewRow currentRow)
        {
            if (currentRow == null)
            {
                return;
            }
            OutboundActivity obj = currentRow.DataBoundItem as OutboundActivity;
            if (obj == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Complete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            obj.Iscomplete = !obj.Iscomplete;
            currentRow.DefaultCellStyle.BackColor = obj.Iscomplete ? Color.LightSeaGreen : inboundDataGridView.DefaultCellStyle.BackColor;

            Outbound outbound = new Outbound(obj.OutboundID);
            outbound.IsComplete = obj.Iscomplete;
            outbound.Change();
        }
        private void outboundDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && previousRowIndex != -1)
            {
                DataGridViewRow previousRow = outboundDataGridView.Rows[previousRowIndex];
                ProcessOubCurrentRow(previousRow);
                previousRowIndex = -1;
                e.Handled = true;
            }
        }
        private void outboundDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                previousRowIndex = outboundDataGridView.CurrentCell.RowIndex;
            }
        }
    }
}

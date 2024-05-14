using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;

namespace Warehouse_IO.View.InboundSource
{
    public partial class InboundForm : ParentForm
    {
        private AddV2 add;
        private EditV2 edit;
        private Remove remove;

        MainForm main;

        List<Inbound> inboundlist;

        public event EventHandler returnMain;

        public InboundForm()
        {
            InitializeComponent();
            inboundlist = new List<Inbound>();
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
            inboundlist = Inbound.GetInboundList();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Invoice");
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Customer");
            dataTable.Columns.Add("Storage");
            dataTable.Columns.Add("Total Quantity", typeof(int));
            dataTable.Columns.Add("Total M3", typeof(double));
            dataTable.Columns.Add("Import", typeof(bool));
            dataTable.Columns.Add("Inbound ID", typeof(int));
            dataTable.Columns.Add("Storage ID", typeof(int));

            double totalM3 = 0.0; // Accumulate total M3 for the shipment

            foreach (Inbound inbound in inboundlist)
            {
                DataRow row = dataTable.NewRow();
                row["Invoice"] = inbound.InvoiceNo;
                row["Date"] = inbound.DeliveryDate.ToString("dd MMM yy");
                row["Customer"] = inbound.Supplier.Name;
                row["Storage"] = inbound.Storage.Name;

                int totalQuantity = 0; // Accumulate total quantity for the shipment

                foreach (KeyValuePair<Product, int> productQty in inbound.QuantityOfProductList)
                {
                    totalQuantity += productQty.Value; // Add individual quantity to total

                    // Check if product has a dimension
                    Warehouse_IO.WHIO.Model.Dimension dimension = productQty.Key.Dimension;
                    if (dimension != null)
                    {
                        double m3PerUnit = dimension.GetM3();
                        totalM3 += productQty.Value * m3PerUnit; // Add M3 per item to total M3
                    }
                }

                row["Total Quantity"] = totalQuantity;
                // No need to calculate M3 in the loop anymore, totalM3 is already accumulated
                row["Total M3"] = totalM3.ToString("0.00");
                row["Import"] = inbound.Inter;
                row["Inbound ID"] = inbound.ID;
                row["Storage ID"] = inbound.Storage.ID;

                dataTable.Rows.Add(row);

                // Reset totalM3 for the next inbound shipment
                totalM3 = 0.0;
            }
            dataTable.DefaultView.Sort = "Date DESC";
            dataGridView.DataSource = dataTable.DefaultView;
            dataGridView.Columns["Inbound ID"].Visible = false;
            dataGridView.Columns["Storage ID"].Visible = false;

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
            int value = (int)selectedRow.Cells[7].Value;
            int storageKey = (int)selectedRow.Cells[8].Value;

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
            int value = (int)selectedRow.Cells[7].Value;
            int storageKey = (int)selectedRow.Cells[8].Value;

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
    }
}

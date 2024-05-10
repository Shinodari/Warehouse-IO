using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;
using System.Linq;

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
            dataTable.Columns.Add("Place");
            dataTable.Columns.Add("TotalM3", typeof(double));
            dataTable.Columns.Add("Items");
            dataTable.Columns.Add("Qty", typeof(int));
            dataTable.Columns.Add("Truck", typeof(int));
            dataTable.Columns.Add("ID", typeof(int));

            foreach (Inbound inbound in inboundlist)
            {
                DataRow row = dataTable.NewRow();
                row["Invoice"] = inbound.InvoiceNo;
                row["Date"] = inbound.DeliveryDate.ToString("dd MMM yy");
                row["Customer"] = inbound.Supplier.Name;
                row["Place"] = inbound.Storage.Name;
                row["Items"] = inbound.QuantityOfProductList.Keys.Count;
                int totalQty = inbound.QuantityOfProductList.Values.Sum();
                row["Qty"] = totalQty;
                double M3perUnit = 0;
                foreach (KeyValuePair<Product, int> productQty in inbound.QuantityOfProductList)
                {
                    Warehouse_IO.WHIO.Model.Dimension dimension = productQty.Key.Dimension;
                    if (dimension != null)
                    {
                        M3perUnit += dimension.GetM3();
                    }
                }
                double TotalM3 = M3perUnit * totalQty;
                row["TotalM3"] = TotalM3.ToString("0.00");
                row["Truck"] = inbound.TruckQuantityPerShipmentList.Keys.Count;
                row["ID"] = inbound.ID;

                dataTable.Rows.Add(row);
            }
            dataTable.DefaultView.Sort = "Date DESC";
            dataGridView.DataSource = dataTable.DefaultView;
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
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[8].Value;
            Global.tempPkey = value;

            edit = new EditV2();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void r_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[8].Value;
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

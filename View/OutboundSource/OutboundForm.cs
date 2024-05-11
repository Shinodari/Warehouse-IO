using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using System.Data;
using System.Linq;
using System.Text;

namespace Warehouse_IO.View.OutboundSource
{
    public partial class OutboundForm : ParentForm
    {
        private Add add;
        private Edit edit;

        MainForm main;

        List<Outbound> outboundlist;

        public event EventHandler returnMain;

        public OutboundForm()
        {
            InitializeComponent();
            outboundlist = new List<Outbound>();
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
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Invoice");
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Customer");
            dataTable.Columns.Add("Place");
            dataTable.Columns.Add("TotalM3", typeof(double));
            dataTable.Columns.Add("Truck", typeof(int));
            dataTable.Columns.Add("ID", typeof(int));

            foreach(Outbound outbound in outboundlist)
            {
                DataRow row = dataTable.NewRow();
                row["Invoice"] = outbound.InvoiceNo;
                row["Date"] = outbound.DeliveryDate.ToString("dd MMM yy");
                row["Customer"] = outbound.Supplier.Name;
                StringBuilder deliveryPlaces = new StringBuilder();
                if(outbound.DeliveryplaceList != null)
                {
                    foreach (Deliveryplace deliveryplace in outbound.DeliveryplaceList)
                    {
                        deliveryPlaces.Append(deliveryplace.Name).Append(", ");
                    }
                    if (deliveryPlaces.Length > 0)
                        deliveryPlaces.Length -= 2;

                    row["Place"] = deliveryPlaces.ToString();
                }
                int totalQty = outbound.QuantityOfProductList.Values.Sum();
                double M3perUnit = 0;
                foreach (KeyValuePair<Product, int> productQty in outbound.QuantityOfProductList)
                {
                    Warehouse_IO.WHIO.Model.Dimension dimension = productQty.Key.Dimension;
                    if (dimension != null)
                    {
                        M3perUnit += dimension.GetM3();
                    }
                }
                double TotalM3 = M3perUnit * totalQty;
                row["TotalM3"] = TotalM3.ToString("0.00");
                row["Truck"] = outbound.TruckQuantityPerShipmentList.Keys.Count;
                row["ID"] = outbound.ID;

                dataTable.Rows.Add(row);
            }
            dataTable.DefaultView.Sort = "Date DESC";
            dataGridView.DataSource = dataTable.DefaultView;
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
            int value = (int)selectedRow.Cells[6].Value;
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
            int value = (int)selectedRow.Cells[6].Value;
            Global.tempPkey = value;

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

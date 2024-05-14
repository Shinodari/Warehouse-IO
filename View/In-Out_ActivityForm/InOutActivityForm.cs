using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public partial class InOutActivityForm : Form
    {
        List<Inbound> inboundlist;

        public event EventHandler returnMain;

        public InOutActivityForm()
        {
            InitializeComponent();
            inboundlist = new List<Inbound>();

            inboundDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateInboundDatagridView();
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
            inboundlist = Inbound.GetInboundList();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Invoice");
            dataTable.Columns.Add("Customer");
            dataTable.Columns.Add("Storage");
            dataTable.Columns.Add("Truck");
            dataTable.Columns.Add("TotalM3", typeof(double));

            DateTime currentDate = DateTime.Today;

            foreach (Inbound inbound in inboundlist)
            {
                /*if (inbound.DeliveryDate.Date == currentDate.Date)
                {
                    
                }*/
                DataRow row = dataTable.NewRow();
                row["Date"] = inbound.DeliveryDate.ToString("dd MMM yy");
                row["Invoice"] = inbound.InvoiceNo;
                row["Customer"] = inbound.Supplier.Name;
                row["Storage"] = inbound.Storage.Name;

                StringBuilder truckTypeAndQuantity = new StringBuilder();
                if (inbound.TruckQuantityPerShipmentList != null)
                {
                    foreach (KeyValuePair<Truck, int> truckInboundQty in inbound.TruckQuantityPerShipmentList)
                    {
                        truckTypeAndQuantity.Append(truckInboundQty.Key.Name)
                            .Append(", ")
                            .Append(truckInboundQty.Value)
                            .Append(" / ");
                    }
                    if (truckTypeAndQuantity.Length > 0)
                    {
                        truckTypeAndQuantity.Length -= 3;
                    }
                    row["Truck"] = truckTypeAndQuantity.ToString();
                }

                int totalQty = inbound.QuantityOfProductList.Values.Sum();
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
                dataTable.Rows.Add(row);
            }
            dataTable.DefaultView.Sort = "Date DESC";
            inboundDataGridView.DataSource = dataTable.DefaultView;
        }
    }
}

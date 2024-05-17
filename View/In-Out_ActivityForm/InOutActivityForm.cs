using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public partial class InOutActivityForm : Form
    {
        List<Inbound> inboundlist;
        List<Outbound> outboundlist;

        private InboundItemForm inboundItemlist;
        private OutboundItemForm outboundItemlist;

        MainForm main;

        public event EventHandler returnMain;

        public InOutActivityForm()
        {
            InitializeComponent();
            inboundlist = new List<Inbound>();
            outboundlist = new List<Outbound>();

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
            inboundlist = Inbound.GetInboundList();

            var sortedInboundList = inboundlist.OrderByDescending(inbound => inbound.DeliveryDate).Take(30).ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Invoice");
            dataTable.Columns.Add("Customer");
            dataTable.Columns.Add("Storage");
            dataTable.Columns.Add("Truck");
            dataTable.Columns.Add("Detail");
            dataTable.Columns.Add("TotalM3", typeof(double));

            dataTable.Columns.Add("Inbound ID", typeof(int)); // column 7
            dataTable.Columns.Add("Storage ID", typeof(int)); // column 8


            DateTime currentDate = DateTime.Today;

            double totalM3 = 0.0; // Accumulate total M3 for the shipment

            foreach (Inbound inbound in sortedInboundList)
            {
                DataRow row = dataTable.NewRow();
                row["Date"] = inbound.DeliveryDate.ToString("dd MMM yy");
                row["Invoice"] = inbound.InvoiceNo;
                row["Customer"] = inbound.Supplier.Name;
                row["Storage"] = inbound.Storage.Name;

                //Truck parts
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

                row["Detail"] = inbound.Detail;
                row["TotalM3"] = totalM3.ToString("0.00");

                row["Inbound ID"] = inbound.ID;
                row["Storage ID"] = inbound.Storage.ID;

                dataTable.Rows.Add(row);

                // Reset totalM3 for the next inbound shipment
                totalM3 = 0.0;
            }
            inboundDataGridView.DataSource = dataTable.DefaultView;

            inboundDataGridView.Columns["Inbound ID"].Visible = false;
            inboundDataGridView.Columns["Storage ID"].Visible = false;
        }

        public void UpdateOutboundDatagridView()
        {
            outboundlist = Outbound.GetOutboundList();

            var sortedOutboundList = outboundlist.OrderByDescending(outbound => outbound.DeliveryDate).Take(30).ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("Invoice");
            dataTable.Columns.Add("Customer");
            dataTable.Columns.Add("Delivery Place");
            dataTable.Columns.Add("Truck");
            dataTable.Columns.Add("Details");
            dataTable.Columns.Add("TotalM3", typeof(double));

            dataTable.Columns.Add("Outbound ID", typeof(int)); // column 7

            DateTime currentDate = DateTime.Today;

            double totalM3 = 0.0; // Accumulate total M3 for the shipment

            foreach (Outbound outbound in sortedOutboundList)
            {
                DataRow row = dataTable.NewRow();
                row["Date"] = outbound.DeliveryDate.ToString("dd MMM yy");
                row["Invoice"] = outbound.InvoiceNo;
                row["Customer"] = outbound.Supplier.Name;

                StringBuilder deliveryPlaces = new StringBuilder();
                if (outbound.DeliveryplaceList != null)
                {
                    foreach (Deliveryplace deliveryplace in outbound.DeliveryplaceList)
                    {
                        deliveryPlaces.Append(deliveryplace.Name).Append(" / ");
                    }
                    if (deliveryPlaces.Length > 0)
                        deliveryPlaces.Length -= 2;

                    row["Delivery Place"] = deliveryPlaces.ToString();
                }

                StringBuilder truckTypeAndQuantity = new StringBuilder();
                if (outbound.TruckQuantityPerShipmentList != null)
                {
                    foreach (KeyValuePair<Truck, int> truckInboundQty in outbound.TruckQuantityPerShipmentList)
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

                int totalQuantity = 0; // Accumulate total quantity for the shipment

                foreach (KeyValuePair<Product, int> productQty in outbound.QuantityOfProductList)
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

                row["Details"] = outbound.Detail;
                row["TotalM3"] = totalM3.ToString("0.00");

                row["Outbound ID"] = outbound.ID;

                dataTable.Rows.Add(row);

                // Reset totalM3 for the next inbound shipment
                totalM3 = 0.0;
            }
            outboundDataGridView.DataSource = dataTable.DefaultView;

            outboundDataGridView.Columns["Outbound ID"].Visible = false;
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
            int value = (int)selectedRow.Cells[7].Value;
            int storageKey = (int)selectedRow.Cells[8].Value;

            Global.tempStorageKey = storageKey;
            Global.tempPkey = value;

            inboundItemlist = new InboundItemForm();
            inboundItemlist.Owner = main;

            inboundItemlist.UpdateGrid += OnUpdate;
            inboundItemlist.ShowDialog();
        }

        private void outboundDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = outboundDataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[7].Value;

            Global.tempPkey = value;

            outboundItemlist = new OutboundItemForm();
            outboundItemlist.Owner = main;

            outboundItemlist.UpdateGrid += OnUpdate;
            outboundItemlist.ShowDialog();
        }
    }
}

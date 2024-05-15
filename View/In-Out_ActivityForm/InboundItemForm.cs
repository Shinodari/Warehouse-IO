using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public partial class InboundItemForm : ItemlistPerShipmentForm
    {
        Inbound inbound;
        Storage storage;

        MainForm main;

        public event EventHandler UpdateGrid;

        public InboundItemForm()
        {
            InitializeComponent();

            //Create selected Instance from InboundFrom
            storage = new Storage(Global.tempStorageKey);
            inbound = new Inbound(Global.tempPkey, storage);

            main = new MainForm();

            itemListDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            UpdateProductGridView();
        }

        private void UpdateProductGridView()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Item");
            datatable.Columns.Add("Description");
            datatable.Columns.Add("Total", typeof(string));
            datatable.Columns.Add("Unit");
            datatable.Columns.Add("Package");
            foreach(KeyValuePair<Product, int> productGridlistEntry in inbound.QuantityOfProductList)
            {
                Product product = productGridlistEntry.Key;
                int quantity = productGridlistEntry.Value;
                DataRow row = datatable.NewRow();
                row["Item"] = product.ID;
                row["Description"] = product.Name;
                double total = quantity * product.UOM.Quantity;
                row["Total"] = total.ToString("N0");
                row["Unit"] = product.UOM.Unit.Name;
                row["Package"] = product.UOM.Package.Name;
                datatable.Rows.Add(row);
            }
            itemListDataGridView.DataSource = datatable.DefaultView;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            UpdateGrid?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}

using System;
using Warehouse_IO.WHIO.Model;
using System.Windows.Forms;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.SupplierFormSource
{
    public partial class RemoveSup : UserControl
    {
        Supplier sRemove;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public RemoveSup()
        {
            InitializeComponent();
        }

        private void removeOKButton_Click(object sender, EventArgs e)
        {
            sRemove = new Supplier(Global.tempPkey);
            if (sRemove.Remove())
            {
                MessageBox.Show(this, "Removed Success");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "It's foreign key");
        }

        private void removeCancle_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

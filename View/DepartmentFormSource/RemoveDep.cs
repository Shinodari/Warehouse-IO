using System;
using Warehouse_IO.WHIO.Model;
using System.Windows.Forms;
using Warehouse_IO.Common;

namespace Warehouse_IO.View
{
    public partial class RemoveDep : UserControl
    {
        Department dRemove;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public RemoveDep()
        {
            InitializeComponent();
        }

        private void removeOkButton_Click(object sender, EventArgs e)
        {
            dRemove = new WHIO.Model.Department(Global.tempPkey);
            if (dRemove.Remove())
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

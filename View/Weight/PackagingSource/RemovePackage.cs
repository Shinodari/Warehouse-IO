using System;
using Warehouse_IO.WHIO.Model;
using System.Windows.Forms;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.Weight.PackagingSource
{
    public partial class RemovePackage : UserControl
    {
        Package removePack;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public RemovePackage()
        {
            InitializeComponent();
        }

        private void removeOK_Click(object sender, EventArgs e)
        {
            removePack = new WHIO.Model.Package(Global.tempPkeyName);
            if (removePack.Remove())
            {
                MessageBox.Show(this, "Removed Success");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "It's foreign key");
        }

        private void removeCancel_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

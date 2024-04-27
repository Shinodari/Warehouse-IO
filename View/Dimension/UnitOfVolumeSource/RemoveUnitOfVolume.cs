using System;
using Warehouse_IO.WHIO.Model;
using System.Windows.Forms;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.Dimension.UnitOfVolumeSource
{
    public partial class RemoveUnitOfVolume : UserControl
    {
        UnitOfDimension uRemove;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public RemoveUnitOfVolume()
        {
            InitializeComponent();
        }

        private void removeOK_Click(object sender, EventArgs e)
        {
            uRemove = new WHIO.Model.UnitOfDimension(Global.tempPkeyName);
            if (uRemove.Remove())
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

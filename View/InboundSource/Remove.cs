using System;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.InboundSource
{
    public partial class Remove : Form
    {
        Inbound remove;

        public event EventHandler UpdateGrid;

        public Remove()
        {
            InitializeComponent();
        }
        private void AttemptRemove()
        {
            remove = new Inbound(Global.tempPkey);
            if (remove.Remove())
            {
                Global.tempPkey = -1;
                MessageBox.Show(this, "Removed Success");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else
            {
                MessageBox.Show(this, "Need to remove Truck and Product First");
                Close();
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            AttemptRemove();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

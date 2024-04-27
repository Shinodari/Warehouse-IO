using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.Weight.PackagingSource
{
    public partial class AddPackage : UserControl
    {
        Package pAdd;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public AddPackage()
        {
            InitializeComponent();
        }

        private void addPackage_Click(object sender, EventArgs e)
        {
            pAdd = new Package(addUnitTextBox.Text);
            if (pAdd.Create())
            {
                MessageBox.Show(this, "Unit Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Create Fail");
        }

        private void cancle_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

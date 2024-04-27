using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.Weight.UnitOfWeightSource
{
    public partial class AddUnitOfWeight : UserControl
    {
        UnitOfUOM uAdd;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public AddUnitOfWeight()
        {
            InitializeComponent();
        }

        private void addUnit_Click(object sender, EventArgs e)
        {
            uAdd = new UnitOfUOM(addUnitTextBox.Text);
            if (uAdd.Create())
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

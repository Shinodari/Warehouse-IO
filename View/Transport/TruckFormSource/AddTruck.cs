using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.TruckFormSource
{
    public partial class AddTruck : UserControl
    {
        Truck tAdd;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public AddTruck()
        {
            InitializeComponent();
        }

        private void addTruckOKButton_Click(object sender, EventArgs e)
        {
            tAdd = new WHIO.Model.Truck(addTruckTextBox.Text, descTruckAdd.Text);
            if (tAdd.Create())
            {
                MessageBox.Show(this, "Truck Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Create Fail");
        }

        private void closeAddTruckBotton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

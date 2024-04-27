using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.TruckFormSource
{
    public partial class EditTruck : UserControl
    {
        Truck tEdit;
        string oldName;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public EditTruck()
        {
            InitializeComponent();
            tEdit = new Truck(Global.tempPkey);
            oldName = tEdit.Name;
        }

        private void EditTruckOKButton_Click(object sender, EventArgs e)
        {
            tEdit.Name = addTruckTextBox.Text;
            tEdit.Description = AddTruckDescTextBox.Text;
            if (tEdit.Change())
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + tEdit.Name);
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Change Fail");
        }

        private void editTruckExitButton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

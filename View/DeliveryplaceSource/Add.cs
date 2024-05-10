using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.DeliveryplaceSource
{
    public partial class Add : AddForm
    {
        Deliveryplace add;

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
        }
        protected override void AttemptAdd()
        {
            add = new Deliveryplace(AddTextBox.Text);
            if (add.Create())
            {
                MessageBox.Show(this, "Delivery Place Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Create Fail");
        }
    }
}

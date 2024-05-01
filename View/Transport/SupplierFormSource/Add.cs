using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Transport.SupplierFormSource
{
    public partial class Add : AddForm
    {
        Supplier add;

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
        }
        protected override void AttemptAdd()
        {
            add = new WHIO.Model.Supplier(AddTextBox.Text);
            if (add.Create())
            {
                MessageBox.Show(this, "Supplier Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Create Fail");
        }
    }
}

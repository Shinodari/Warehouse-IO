using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Weight.UnitOfWeightSource
{
    public partial class Add : AddForm
    {
        UnitOfUOM add;

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
        }
        protected override void AttemptAdd()
        {
            add = new UnitOfUOM(AddTextBox.Text);
            if (add.Create())
            {
                MessageBox.Show(this, "Unit Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Create Fail");
        }
    }
}

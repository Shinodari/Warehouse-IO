using System;
using System.Windows.Forms;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.Weight.PackagingSource
{
    public partial class Add : AddForm
    {
        Package add;

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
        }
        protected override void AttemptAdd()
        {
            add = new Package(AddTextBox.Text);
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

using System;
using System.Windows.Forms;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.DepartmentFormSource
{
    public partial class Add : AddForm
    {
        Department add;

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
        }
        protected override void AttemptAdd()
        {
            add = new Department(AddTextBox.Text);
            if (add.Create())
            {
                MessageBox.Show(this, "Department Created");
                Close();
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Create Fail");
        }
    }
}

using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO
{
    public partial class AddDep : UserControl
    {
        Department dAdd;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public AddDep()
        {
            InitializeComponent();
        }

        private void addDepOKButton_Click(object sender, EventArgs e)
        {
            dAdd = new Department(addDepTextBox.Text);
            if (dAdd.Create())
            {
                MessageBox.Show(this, "Department Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Create Fail");
        }

        private void closeAddDepCancelButton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

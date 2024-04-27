using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.SupplierFormSource
{
    public partial class AddSup : UserControl
    {
        Supplier sAdd;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public AddSup()
        {
            InitializeComponent();
        }

        private void addSupOKButton_Click(object sender, EventArgs e)
        {
            sAdd = new WHIO.Model.Supplier(addSupTextBox.Text);
            if (sAdd.Create())
            {
                MessageBox.Show(this, "Supplier Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Create Fail");
        }

        private void closeAddSupBotton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

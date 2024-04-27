using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.StorageFormSource
{
    public partial class AddStorage : UserControl
    {
        Storage sAdd;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public AddStorage()
        {
            InitializeComponent();
        }

        private void addStoOKButton_Click(object sender, EventArgs e)
        {
            sAdd = new Storage(addStoTextBox.Text);
            if (sAdd.Create())
            {
                MessageBox.Show(this, "Storage Location Created");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Create Fail");
        }

        private void closeAddStoButton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

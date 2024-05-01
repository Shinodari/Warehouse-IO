using System;
using System.Windows.Forms;

namespace Warehouse_IO.View.Add_Edit_Remove_Components
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            AddTextBox.KeyPress += OKKeyPress;
            CancelButton.Click += CancelButton_Click;
            this.Focus();
        }

        private void OKAddClick(object sender, EventArgs e)
        {
            AttemptAdd();
        }
        private void OKKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptAdd();
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void AttemptAdd()
        {
            // put add logic here
        }
    }
}

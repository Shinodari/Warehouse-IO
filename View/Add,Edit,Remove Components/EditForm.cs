using System;
using System.Windows.Forms;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.Add_Edit_Remove_Components
{

    public partial class EditForm : Form
    {
        protected string oldName;

        public EditForm()
        {
            InitializeComponent();
            EditTextBox.KeyPress += OKEdit_KeyPress;
            CancelButton.Click += CancelButton_Click;
            this.Focus();
        }

        private void OKEdit_Click(object sender, EventArgs e)
        {
            AttemptEdit();
        }

        private void OKEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptEdit();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void AttemptEdit()
        {
            // put add logic here
        }
    }
}

using System;
using System.Windows.Forms;

namespace Warehouse_IO.View.Add_Edit_Remove_Components
{
    public partial class RemoveForm : Form
    {
        public RemoveForm()
        {
            InitializeComponent();
            OKButton.KeyPress += OKButton_KeyPress;
            CancelButton.Click += CancelButton_Click;
            this.Focus();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            AttemptRemove();
        }

        private void OKButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptRemove();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected virtual void AttemptRemove()
        {
            // put add logic here
        }
    }
}

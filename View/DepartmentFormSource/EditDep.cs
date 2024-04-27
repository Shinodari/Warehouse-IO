using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO
{
    public partial class EditDep : UserControl
    {
        Department dEdit;
        string oldName;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public EditDep()
        {
            InitializeComponent();
            dEdit = new Department(Global.tempPkey);
            oldName = dEdit.Name;
        }

        private void EditDep_Load(object sender, EventArgs e)
        {
            oldNameLabel.Text = oldName;
        }
        private void editDepOKButton_Click(object sender, EventArgs e)
        {
            dEdit.Name = addDepTextBox.Text;
            if (dEdit.Change())
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + dEdit.Name);
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Change Fail");
        }

        private void editDepExitButton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        } 
    }
}

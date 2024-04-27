using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.SupplierFormSource
{
    public partial class EditSup : UserControl
    {
        Supplier sEdit;
        string oldName;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public EditSup()
        {
            InitializeComponent();
            sEdit = new WHIO.Model.Supplier(Global.tempPkey);
            oldName = sEdit.Name;
        }

        private void EditSup_Load(object sender, EventArgs e)
        {
            oldNameLabel.Text = oldName;
        }

        private void EditSupOKButton_Click(object sender, EventArgs e)
        {
            sEdit.Name = addSupTextBox.Text;
            if (sEdit.Change())
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + sEdit.Name);
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Change Fail");
        }

        private void editSupExitButton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.Weight.PackagingSource
{
    public partial class EditPackage : UserControl
    {
        Package pEdit;
        string oldName;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public EditPackage()
        {
            InitializeComponent();
            pEdit = new WHIO.Model.Package(Global.tempPkeyName);
            oldName = pEdit.Name;
        }

        private void edit_Load(object sender, EventArgs e)
        {
            oldNameLabel.Text = oldName;
        }

        private void editOK_Click(object sender, EventArgs e)
        {
            pEdit.Name = addTextBox.Text;
            if (pEdit.Change())
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + pEdit.Name);
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Change Fail");
        }

        private void editCancel_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

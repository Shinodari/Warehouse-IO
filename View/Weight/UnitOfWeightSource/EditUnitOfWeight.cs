using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.Weight.UnitOfWeightSource
{
    public partial class EditUnitOfWeight : UserControl
    {
        UnitOfUOM uEdit;
        string oldName;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public EditUnitOfWeight()
        {
            InitializeComponent();
            uEdit = new UnitOfUOM(Global.tempPkeyName);
            oldName = uEdit.Name;
        }

        private void edit_Load(object sender, EventArgs e)
        {
            oldNameLabel.Text = oldName;
        }

        private void editOK_Click(object sender, EventArgs e)
        {
            uEdit.Name = addTextBox.Text;
            if (uEdit.Change())
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + uEdit.Name);
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

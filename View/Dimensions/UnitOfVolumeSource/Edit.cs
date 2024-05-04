using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Dimension.UnitOfVolumeSource
{
    public partial class Edit : EditForm
    {
        UnitOfDimension edit;

        public event EventHandler UpdateGrid;

        public Edit()
        {
            InitializeComponent();
            edit = new UnitOfDimension(Global.tempPkeyName);
            oldName = edit.Name;
        }
        protected override void AttemptEdit()
        {
            edit.Name = EditTextBox.Text;
            if (edit.Change()&&edit.Name!=oldName)
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + edit.Name);
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Change Fail");
        }

    }
}

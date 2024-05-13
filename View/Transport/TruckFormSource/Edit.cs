using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Transport.TruckFormSource
{
    public partial class Edit : EditForm
    {
        Truck edit;

        public event EventHandler UpdateGrid;

        public Edit()
        {
            InitializeComponent();
            edit = new WHIO.Model.Truck(Global.tempPkey);
            EditTextBox.Text = edit.Name;
            oldName = edit.Name;
        }
        protected override void AttemptEdit()
        {
            edit.Name = EditTextBox.Text;
            edit.Description = descriptionTextBox.Text;
            if (edit.Change())
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + edit.Name);
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Change Fail");
        }
    }
}

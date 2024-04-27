using System;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.StorageFormSource
{
    public partial class EditStorage : UserControl
    {
        Storage sEdit;
        string oldName;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public EditStorage()
        {
            InitializeComponent();
            sEdit = new Storage(Global.tempPkey);
            oldName = sEdit.Name;
        }

        private void EditSto_Load(object sender, EventArgs e)
        {
            oldStoNameLabel.Text = oldName;
        }

        private void editStoOKButton_Click(object sender, EventArgs e)
        {
            sEdit.Name = addStoTextBox.Text;
            if (sEdit.Change())
            {
                MessageBox.Show(this, "Edit Completed Old name : " + oldName + " New name : " + sEdit.Name);
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Change Fail");
        }

        private void editStoExitButton_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}

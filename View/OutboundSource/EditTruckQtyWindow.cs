using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.OutboundSource
{
    public partial class EditTruckQtyWindow : EditForm
    {
        public static int editQty;

        public EditTruckQtyWindow()
        {
            InitializeComponent();
        }

        private void EditQuantity()
        {
            int qty = int.Parse(EditTextBox.Text);
            if (qty > 0)
            {
                Truck truck = new WHIO.Model.Truck(Global.tempPkey);
                editQty = qty;
                EditTextBox.Text = "";
                Close();
            }
            else MessageBox.Show(this, "Need number more than 0");
        }

        private void EditTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EditQuantity();
            }
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            EditTextBox.Text = "";
            Close();
        }

        private void OKEdit_Click(object sender, System.EventArgs e)
        {
            EditQuantity();
        }
    }
}

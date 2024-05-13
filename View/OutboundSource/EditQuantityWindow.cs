using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.OutboundSource
{

    public partial class EditQuantityWindow : Form
    {
        public static int editQty;

        public EditQuantityWindow()
        {
            InitializeComponent();
        }
        private void EditQuantity()
        {
            double qty = double.Parse(EditTextBox.Text);
            if (qty > 0)
            {
                Product product = new Product(Global.tempPkey);
                editQty = product.GetQuantity(qty);
                EditTextBox.Text = "";
                Close();
            }
            else MessageBox.Show(this, "Need number more than 0");
        }

        private void EditTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
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

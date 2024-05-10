using System.Windows.Forms;

namespace Warehouse_IO.View.InboundSource
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
            string qty = EditTextBox.Text;
            if (int.TryParse(qty, out editQty))
            {
                if (editQty > 0)
                {
                    EditTextBox.Text = "";
                    Close();
                }
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

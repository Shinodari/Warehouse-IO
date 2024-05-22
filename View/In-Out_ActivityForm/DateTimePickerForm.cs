using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.Chart;
using Warehouse_IO.Common;
using Warehouse_IO.Control;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public partial class DateTimePickerForm : Form
    {
        private ChartDisplayForm chartform;
        private ByCustomerOperation chartByCustomer;

        MainForm main;

        List<SupplierForGetList> suplist;

        public DateTimePickerForm()
        {
            InitializeComponent();
            UpdateComponents();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Global.fromDate1Timeline = firstFormDatePicker.Value.Date;
            Global.toDate1Timeline = firstToDatePicker.Value.Date;

            Global.fromDate2Timeline = secondFromDatePicker.Value.Date;
            Global.toDate2Timeline = secondToDatePicker.Value.Date;


            if (customerComboBox.Text == "OVERALL")
            {
                chartform = new ChartDisplayForm();
                chartform.Owner = main;

                chartform.ShowDialog();
            }
            else if (customerComboBox.SelectedIndex >= 0)
            {
                string selectedSupName = customerComboBox.SelectedItem.ToString();

                Global.tempPkeyName = selectedSupName;
                chartByCustomer = new ByCustomerOperation();
                chartByCustomer.Owner = main;

                chartByCustomer.ShowDialog();
            }
            else MessageBox.Show(this,"Please select any dataset");

        }

        private void UpdateComponents()
        {
            suplist = SupplierForGetList.GetSupplierList();
            suplist.Sort((x, y) => x.name.CompareTo(y.name));
            customerComboBox.Items.Clear();

            customerComboBox.Items.Add("OVERALL");
            foreach (SupplierForGetList sup in suplist)
            {
                customerComboBox.Items.Add(sup.name);
            }
        }
    }
}

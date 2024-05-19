using System;
using System.Windows.Forms;
using Warehouse_IO.Chart;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public partial class DateTimePickerForm : Form
    {
        private ChartDisplayForm chartform;
        MainForm main;

        public DateTimePickerForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Global.fromDate1Timeline = firstFormDatePicker.Value;
            Global.toDate1Timeline = firstToDatePicker.Value;

            Global.fromDate2Timeline = secondFromDatePicker.Value;
            Global.toDate2Timeline = secondToDatePicker.Value;

            chartform = new ChartDisplayForm();
            chartform.Owner = main;

            chartform.ShowDialog();
        }
    }
}

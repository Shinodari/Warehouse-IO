using Warehouse_IO.WHIO.Model;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Dimensions.DimensionSource
{
    public partial class Add : AddEditDimensionFrom
    {
        Warehouse_IO.WHIO.Model.Dimension add;
        UnitOfDimension unitOfDimensionName;
        List<UnitOfDimension> unitOfDimensionNameList;

        double height = 1;
        double width = 1;
        double length = 1;
        bool conversionFailed = false;

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
            nameTextBox.KeyPress += AddButton_KeyPress;
            widthTextBox.KeyPress += AddButton_KeyPress;
            lengthTextBox.KeyPress += AddButton_KeyPress;
            heightTextBox.KeyPress += AddButton_KeyPress;
            unitOfVolumeListBox.KeyPress += AddButton_KeyPress;
            cancelButton.Click += cancelButton_Click;
            unitOfDimensionNameList = new List<UnitOfDimension>();
            updateList();
        }
        private void updateList()
        {
            unitOfDimensionNameList = UnitOfDimension.GetUnitOfDimension();
            unitOfDimensionNameList.Sort((x, y) => x.Name.CompareTo(y.Name));

            unitOfVolumeListBox.Items.Clear();

            foreach (UnitOfDimension dimension in unitOfDimensionNameList)
            {
                unitOfVolumeListBox.Items.Add(dimension.Name);
            }
        }

        private void AttemptAdd()
        {
            string name = nameTextBox.Text;
            try
            {
                width = convertToDouble(widthTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Width Format");
                conversionFailed = true;
            }
            try
            {
                length = convertToDouble(lengthTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Length Format");
                conversionFailed = true;
            }
            try
            {
                height = convertToDouble(heightTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Height Format");
                conversionFailed = true;
            }
            if (conversionFailed)
            {
                MessageBox.Show("Create Fail");
                conversionFailed = false;
                return;
            }
            if (unitOfVolumeListBox.SelectedItem != null)
            {
                string selectedUnitOfDimension = unitOfVolumeListBox.SelectedItem.ToString();
                unitOfDimensionName = new UnitOfDimension(selectedUnitOfDimension);
            }
            else
            {
                MessageBox.Show("Please select Unit of Volume");
                return;
            }
            add = new WHIO.Model.Dimension(width, length, height, unitOfDimensionName,name);
            if (add.Create())
            {
                MessageBox.Show(this, "Dimension Create");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Create Fail");
            return;
        }

        private double convertToDouble(string text)
        {
            double value;
            if (!double.TryParse(text, out value))
            {
                throw new FormatException();
            }
            return value;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AttemptAdd();
        }
        private void AddButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptAdd();
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

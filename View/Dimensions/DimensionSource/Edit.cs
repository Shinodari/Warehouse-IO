using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Dimensions.DimensionSource
{
    public partial class Edit : AddEditDimensionFrom
    {
        Warehouse_IO.WHIO.Model.Dimension edit;
        List<UnitOfDimension> unitOfDimensionNameList;

        double height = 1;
        double width = 1;
        double length = 1;
        bool conversionFailed = false;

        public event EventHandler UpdateGrid;

        public Edit()
        {
            InitializeComponent();
            edit = new WHIO.Model.Dimension(Global.tempPkey);
            unitOfDimensionNameList = new List<UnitOfDimension>();
            updateList();

            widthTextBox.Text = edit.Width.ToString();
            lengthTextBox.Text = edit.Length.ToString();
            heightTextBox.Text = edit.Height.ToString();
            unitOfVolumeListBox.SelectedItem = edit.Unit.Name;

            nameTextBox.KeyPress += AddButton_KeyPress;
            widthTextBox.KeyPress += AddButton_KeyPress;
            lengthTextBox.KeyPress += AddButton_KeyPress;
            heightTextBox.KeyPress += AddButton_KeyPress;
            unitOfVolumeListBox.KeyPress += AddButton_KeyPress;
            cancelButton.Click += cancelButton_Click;      
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

        private void AttemptEdit()
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
                MessageBox.Show("Updated Fail");
                conversionFailed = false;
                return;
            }
            string selectedUnitOfDimension = unitOfVolumeListBox.SelectedItem.ToString();
            edit.Width = width;
            edit.Length = length;
            edit.Height = height;
            if (edit.Change())
            {
                MessageBox.Show(this, "Dimension Updated");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Updated Fail");
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
            AttemptEdit();
        }
        private void AddButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptEdit();
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

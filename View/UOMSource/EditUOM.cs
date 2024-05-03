using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.UOMSource
{
    public partial class EditUOM : AddEditUOMForm
    {
        UOM edit;
        List<Package> packageList;
        List<UnitOfUOM> unitofUomList;

        double value;

        public event EventHandler UpdateGrid;

        public EditUOM()
        {
            InitializeComponent();
            edit = new UOM(Global.tempPkey);
            packageList = new List<Package>();
            unitofUomList = new List<UnitOfUOM>();
            updateList();

            quantityTextBox.Text = edit.Quantity.ToString();
            unitOfWeightListBox.SelectedItem = edit.Unit.Name;
            perPackageListBox.SelectedItem = edit.Package.Name;

            quantityTextBox.KeyPress += addButton_KeyPress;
            unitOfWeightListBox.KeyPress += addButton_KeyPress;
            perPackageListBox.KeyPress += addButton_KeyPress;
            cancelButton.Click += cancelButton_Click;  
        }

        private void updateList()
        {
            packageList = Package.GetPackageList();
            unitofUomList = UnitOfUOM.GetUnitOfUOM();
            packageList.Sort((x, y) => x.Name.CompareTo(y.Name));
            unitofUomList.Sort((x, y) => x.Name.CompareTo(y.Name));

            unitOfWeightListBox.Items.Clear();
            perPackageListBox.Items.Clear();

            foreach (var package in packageList)
            {
                perPackageListBox.Items.Add(package.Name);
            }
            foreach (var unitOfUOM in unitofUomList)
            {
                unitOfWeightListBox.Items.Add(unitOfUOM.Name);
            }
        }

        private void AttemptEdit()
        {
            try
            {
                value = convertToDouble(quantityTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Quantity Format");
            }
            string selectedUnitOfWeight = unitOfWeightListBox.SelectedItem.ToString();
            string selectedPerPackage = perPackageListBox.SelectedItem.ToString();
            edit.Quantity = value;
            edit.Unit.Name = selectedUnitOfWeight;
            edit.Package.Name = selectedPerPackage;
            if (edit.Change())
            {
                MessageBox.Show(this, "Change Completed");
                Close();
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "Change Fail");
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

        private void addButton_Click(object sender, EventArgs e)
        {
            AttemptEdit();
        }
        private void addButton_KeyPress(object sender, KeyPressEventArgs e)
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

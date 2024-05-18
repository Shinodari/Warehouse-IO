using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Warehouse_IO.View.Weight.PackagingSource;
using Warehouse_IO.View.Weight.UnitOfWeightSource;

namespace Warehouse_IO.View.UOMSource
{
    public partial class AddUOM : AddEditUOMForm
    {
        UOM add;
        Package package;
        List<PackageForGetList> packageList;
        UnitOfUOM unitofUom;
        List<UnitOfUOMForGetList> unitofUomList;

        double value = 1;

        public event EventHandler UpdateGrid;

        public AddUOM()
        {
            InitializeComponent();
            quantityTextBox.KeyPress += addButton_KeyPress;
            nameTextBox.KeyPress += addButton_KeyPress;
            unitOfWeightListBox.KeyPress += addButton_KeyPress;
            perPackageListBox.KeyPress += addButton_KeyPress;
            cancelButton.Click += cancelButton_Click;

            packageList = new List<PackageForGetList>();
            unitofUomList = new List<UnitOfUOMForGetList>();
            updateList();
        }

        private void updateList()
        {
            packageList = Package.GetPackageList();
            unitofUomList = UnitOfUOM.GetUnitOfUOM();
            packageList.Sort((x, y) => x.Name.CompareTo(y.Name));
            unitofUomList.Sort((x, y) => x.Name.CompareTo(y.Name));

            unitOfWeightListBox.Items.Clear();
            perPackageListBox.Items.Clear();

            foreach (PackageForGetList package in packageList)
            {
                perPackageListBox.Items.Add(package.Name);
            }
            foreach (UnitOfUOMForGetList unitOfUOM in unitofUomList)
            {
                unitOfWeightListBox.Items.Add(unitOfUOM.Name);
            }
        } 

        private void AttemptAdd()
        {
            try
            {
                value = convertToDouble(quantityTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Quantity Format");
            }
            if (unitOfWeightListBox.SelectedItem != null)
            {
                string selectedUnitOfWeight = unitOfWeightListBox.SelectedItem.ToString();
                unitofUom = new UnitOfUOM(selectedUnitOfWeight);
            }
            else
            {
                MessageBox.Show("Please select Unit of Weight");
                return;
            }
            if (perPackageListBox.SelectedItem != null)
            {
                string selectedPerPackage = perPackageListBox.SelectedItem.ToString();
                package = new Package(selectedPerPackage);
            }
            else
            {
                MessageBox.Show("Please select Package");
                return;
            }
            add = new UOM(value, unitofUom, package, nameTextBox.Text);
            if (add.Create())
            {
                MessageBox.Show(this, "UOM Create");
                Close();
                UpdateGrid?.Invoke(this, EventArgs.Empty);
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

        private void addButton_Click(object sender, EventArgs e)
        {
            AttemptAdd();
        }
        private void addButton_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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

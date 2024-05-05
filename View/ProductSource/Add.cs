using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Warehouse_IO.View.ProductSource
{
    public partial class Add : AddEditProductForm
    {
        Product add;
        UOM uom;
        Warehouse_IO.WHIO.Model.Dimension dimension;
        List<UOM> uomList;
        List<Warehouse_IO.WHIO.Model.Dimension> dimensionList;
        private List<int> dimensionId = new List<int>();
        private List<int> uomId = new List<int>();

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
            nameTextBox.KeyPress += AddButton_KeyPress;
            UoMListBox.KeyPress += AddButton_KeyPress;
            dimensionListBox.KeyPress += AddButton_KeyPress;

            dimensionList = new List<Warehouse_IO.WHIO.Model.Dimension>();
            uomList = new List<UOM>();
            updateList();
        }

        private void updateList()
        {
            dimensionList = Warehouse_IO.WHIO.Model.Dimension.GetDimensionList();
            uomList = UOM.GetUOMList();
            dimensionList.Sort((x, y) => x.Name.CompareTo(y.Name));
            uomList.Sort((x, y) => x.Name.CompareTo(y.Name));

            UoMListBox.Items.Clear();
            dimensionListBox.Items.Clear();

            foreach (Warehouse_IO.WHIO.Model.Dimension dimension in dimensionList)
            {
                string formattedDimension = $"{dimension.Width} x {dimension.Length} x {dimension.Height} {dimension.Unit.Name} {dimension.Name}";
                dimensionListBox.Items.Add(formattedDimension);
                dimensionId.Add(dimension.ID);
            }
            foreach (UOM uom in uomList)
            {
                string formattedDimension = $"{uom.Quantity}{uom.Unit.Name}/{uom.Package.Name} {uom.Name}";
                UoMListBox.Items.Add(formattedDimension);
                uomId.Add(uom.ID);
            }
        }

        private void AttemptAdd()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a product name.");
                return;
            }
            int selectedUOMIndex = UoMListBox.SelectedIndex;
            if (selectedUOMIndex >= 0 && selectedUOMIndex < uomId.Count)
            {
                int selectedUOMID = uomId[selectedUOMIndex];
                uom = new UOM(selectedUOMID);
            }
            else
            {
                MessageBox.Show(this, "Please select UOM");
                return;
            }
                int selectedDimensionIndex = dimensionListBox.SelectedIndex;
            if (selectedDimensionIndex >= 0 && selectedDimensionIndex < dimensionId.Count)
            {
                int selectedDimensionID = dimensionId[selectedDimensionIndex];
                dimension = new Warehouse_IO.WHIO.Model.Dimension(selectedDimensionID);
            }
            else
            {
                MessageBox.Show(this, "Please select Dimension");
                return;
            }
            add = new Product(nameTextBox.Text,uom,dimension);
            if (add.Create())
            {
                MessageBox.Show(this, "Product Create");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Create Fail");
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

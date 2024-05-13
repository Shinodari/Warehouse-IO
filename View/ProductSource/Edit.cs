using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.ProductSource
{
    public partial class Edit : AddEditProductForm
    {
        Product edit;
        UOM uom;
        Warehouse_IO.WHIO.Model.Dimension dimension;
        List<UOM> uomList;
        List<Warehouse_IO.WHIO.Model.Dimension> dimensionList;
        private List<int> dimensionId = new List<int>();
        private List<int> uomId = new List<int>();

        public event EventHandler UpdateGrid;

        public Edit()
        {
            InitializeComponent();
            updateList();
            edit = new Product(Global.tempPkey);
            nameTextBox.Text = edit.Name.ToString();

            //Selected data in listbox referred by ID in private list
            int uomIndex = uomId.IndexOf(edit.UOM.ID);
            if (uomIndex >= 0)
            {
                UoMListBox.SelectedIndex = uomIndex;
            }
            int dimensionIndex = dimensionId.IndexOf(edit.Dimension.ID);
            if (dimensionIndex >= 0)
            {
                dimensionListBox.SelectedIndex = dimensionIndex;
            }

            nameTextBox.KeyPress += AddButton_KeyPress;
            UoMListBox.KeyPress += AddButton_KeyPress;
            dimensionListBox.KeyPress += AddButton_KeyPress;

            dimensionList = new List<Warehouse_IO.WHIO.Model.Dimension>();
            uomList = new List<UOM>();
        }
        private void updateList()
        {
            dimensionList = Warehouse_IO.WHIO.Model.Dimension.GetDimensionList();
            uomList = UOM.GetUOMList();
            dimensionList.Sort((x, y) => x.GetM3().CompareTo(y.GetM3()));
            uomList.Sort((x, y) => x.Name.CompareTo(y.Name));

            UoMListBox.Items.Clear();
            dimensionListBox.Items.Clear();

            foreach (Warehouse_IO.WHIO.Model.Dimension dimension in dimensionList)
            {
                string formattedDimension = $"{dimension.GetM3()} /// {dimension.Unit.Name} {dimension.Name}";
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
        private void AttemptEdit()
        {
            edit.Name = nameTextBox.Text;
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
                edit.UOM = uom;
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
                edit.Dimension = dimension;
            }
            else
            {
                MessageBox.Show(this, "Please select Dimension");
                return;
            }
            if (edit.Change())
            {
                MessageBox.Show(this, "Product has edited");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "Edited Fail");

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

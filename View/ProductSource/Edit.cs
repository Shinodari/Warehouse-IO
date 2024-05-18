using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using Warehouse_IO.View.UOMSource;

namespace Warehouse_IO.View.ProductSource
{
    public partial class Edit : AddEditProductForm
    {
        Product edit;
        UOM uom;
        Warehouse_IO.WHIO.Model.Dimension dimension;
        List<UOMForGetList> uomList;
        List<Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList> dimensionList;

        //Variable for tracking Dimension and UOM in listBox
        string targetDimension;
        string targetUOM;
        private readonly Dictionary<string, UOMForGetList> uomforSearchList = new Dictionary<string, UOMForGetList>();
        private readonly Dictionary<string, Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList> dimensionforSearchList = new Dictionary<string, Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList>();

        public event EventHandler UpdateGrid;

        public Edit()
        {
            InitializeComponent();

            nameTextBox.Enabled = false;

            nameTextBox.KeyPress += AddButton_KeyPress;
            UoMListBox.KeyPress += AddButton_KeyPress;
            dimensionListBox.KeyPress += AddButton_KeyPress;

            edit = new Product(Global.tempPkeyName);
            //Create text pattern select in listbox
            targetDimension = $"{edit.Dimension.M3} // {edit.Dimension.Unit.Name} {edit.Dimension.Name}";
            targetUOM = $"{edit.UOM.Quantity}{edit.UOM.Unit.Name}/{edit.UOM.Package.Name} {edit.UOM.Name}";
            nameTextBox.Text = edit.ID;
            detailTextBox.Text = edit.Name;

            dimensionList = new List<Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList>();
            uomList = new List<UOMForGetList>();

            updateList();
        }
        private void updateList()
        {
            dimensionList = Warehouse_IO.WHIO.Model.Dimension.GetDimensionList();
            uomList = UOM.GetUOMList();
            dimensionList.Sort((x, y) => x.M3.CompareTo(y.M3));
            uomList.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));

            UoMListBox.Items.Clear();
            dimensionListBox.Items.Clear();

            foreach (Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList dimension in dimensionList)
            {
                string formattedDimension = $"{dimension.M3} // {dimension.UnitOfVolume} {dimension.Details}";
                dimensionListBox.Items.Add(formattedDimension);

                dimensionforSearchList[formattedDimension] = dimension;
            }
            foreach (UOMForGetList uom in uomList)
            {
                string formattedUOM = $"{uom.Quantity}{uom.Unit}/{uom.Package}";
                UoMListBox.Items.Add(formattedUOM);

                uomforSearchList[formattedUOM] = uom;
            }
            SelectListBoxItem(dimensionListBox, targetDimension);
            SelectListBoxItem(UoMListBox, targetUOM);
        }

        //Method for select item in listbox
        private void SelectListBoxItem(ListBox listBox, string targetItem)
        {
            if (listBox.Items.Contains(targetItem))
            {
                int index = listBox.FindString(targetItem);
                if (index != -1)
                {
                    listBox.SetSelected(index, true);
                }
            }
        }

        private void AttemptEdit()
        {   
            edit.Name = detailTextBox.Text;
            if (UoMListBox.SelectedIndex >= 0)
            {
                string selectedUOMName = (string)UoMListBox.SelectedItem;
                if (uomforSearchList.ContainsKey(selectedUOMName))
                {
                    UOMForGetList selectedUOM = uomforSearchList[selectedUOMName];
                    int selectedID = selectedUOM.ID;

                    uom = new UOM(selectedID);
                    edit.UOM = uom;
                }
            }
            else
            {
                MessageBox.Show(this, "Please select UOM");
                return;
            }
            if (dimensionListBox.SelectedIndex >= 0)
            {
                string selectedDimensionName = (string)dimensionListBox.SelectedItem;
                if (dimensionforSearchList.ContainsKey(selectedDimensionName))
                {
                    Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList selectedDimension = dimensionforSearchList[selectedDimensionName];
                    int selectedID = selectedDimension.ID;

                    dimension = new WHIO.Model.Dimension(selectedID);
                    edit.Dimension = dimension;
                }
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

        //Searching UOM algorithm
        private void UoMSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = UoMSearchTextBox.Text.ToLower();

            UoMListBox.Items.Clear();

            foreach (UOMForGetList item in uomList)
            {
                string formattedDimension = $"{item.Quantity}{item.Unit}/{item.Package} {item.Details}";
                if (formattedDimension.ToLower().Contains(searchText))
                {
                    UoMListBox.Items.Add(formattedDimension);
                }
            }
        }

        //Searching Dimension algorithm
        private void dimensionSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = dimensionSearchTextBox.Text.ToLower();

            dimensionListBox.Items.Clear();

            foreach (Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList item in dimensionList)
            {
                string formattedDimension = $"{item.M3} // {item.UnitOfVolume} {item.Details}";
                if (formattedDimension.ToLower().Contains(searchText))
                {
                    dimensionListBox.Items.Add(formattedDimension);
                }
            }
        }
    }
}

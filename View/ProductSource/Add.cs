using Warehouse_IO.WHIO.Model;
using Warehouse_IO.View.Add_Edit_Remove_Components;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Warehouse_IO.View.UOMSource;

namespace Warehouse_IO.View.ProductSource
{
    public partial class Add : AddEditProductForm
    {
        Product add;
        UOM uom;
        Warehouse_IO.WHIO.Model.Dimension dimension;
        List<UOMForGetList> uomList;
        List<Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList> dimensionList;

        public event EventHandler UpdateGrid;

        public Add()
        {
            InitializeComponent();
            nameTextBox.KeyPress += AddButton_KeyPress;
            UoMListBox.KeyPress += AddButton_KeyPress;
            dimensionListBox.KeyPress += AddButton_KeyPress;

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
            //Dynamic listbox need to track by dictionary
            foreach (Warehouse_IO.View.Dimensions.DimensionSource.DimensionForGetList dimension in dimensionList)
            {
                string formattedDimension = $"{dimension.M3} // {dimension.UnitOfVolume}";
                DimensionWrapper dimwrap = new DimensionWrapper(formattedDimension, dimension.ID);
                dimensionListBox.Items.Add(dimwrap);
            }
            //Dynamic listbox need to track by dictionary
            foreach (UOMForGetList uom in uomList)
            {
                string formattedUOM = $"{uom.Quantity}{uom.Unit}/{uom.Package} {uom.Details}";
                UOMWrapper uomwrap = new UOMWrapper(formattedUOM, uom.ID);
                UoMListBox.Items.Add(uomwrap);
            }
        }

        private void AttemptAdd()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a product name.");
                return;
            }
            if (UoMListBox.SelectedIndex >=0)
            {
                UOMWrapper selectedWrap = (UOMWrapper)UoMListBox.SelectedItem;
                int uomid = selectedWrap.UomID;
                uom = new UOM(uomid);
            }
            else
            {
                MessageBox.Show(this, "Please select UOM");
                return;
            }
            if (dimensionListBox.SelectedIndex >= 0)
            {
                DimensionWrapper selectedWrap = (DimensionWrapper)dimensionListBox.SelectedItem;
                int dimid = selectedWrap.DimensionID;
                dimension = new WHIO.Model.Dimension(dimid);
            }
            else
            {
                MessageBox.Show(this, "Please select Dimension");
                return;
            }
            add = new Product(nameTextBox.Text,detailTextBox.Text,uom,dimension);
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

        //Searching UOM algorithm
        private void UoMSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = UoMSearchTextBox.Text.ToLower();

            UoMListBox.Items.Clear();

            foreach (UOMForGetList item in uomList)
            {
                string formattedDimension = $"{item.Quantity}{item.Unit}/{item.Package}";
                if (formattedDimension.ToLower().Contains(searchText))
                {
                    UOMWrapper uomwrap = new UOMWrapper(formattedDimension, item.ID);
                    UoMListBox.Items.Add(uomwrap);
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
                    DimensionWrapper dimwrap = new DimensionWrapper(formattedDimension, item.ID);
                    dimensionListBox.Items.Add(dimwrap);
                }
            }
        }
        public class DimensionWrapper
        {
            public string FormattedDimension { get; set; }
            public int DimensionID { get; set; }

            public DimensionWrapper(string formattedDimension, int dimensionID)
            {
                FormattedDimension = formattedDimension;
                DimensionID = dimensionID;
            }

            public override string ToString()
            {
                return FormattedDimension;
            }
        }
        public class UOMWrapper
        {
            public string FormattedUOM { get; set; }
            public int UomID { get; set; }

            public UOMWrapper(string formatUOM, int uomID)
            {
                FormattedUOM = formatUOM;
                UomID = uomID;
            }

            public override string ToString()
            {
                return FormattedUOM;
            }
        }
    }
}

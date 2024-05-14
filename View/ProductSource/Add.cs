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

        //Variable for tracking Dimension and UOM in listBox
        private readonly Dictionary<string, UOM> uomforSearchList = new Dictionary<string, UOM>();
        private readonly Dictionary<string, Warehouse_IO.WHIO.Model.Dimension> dimensionforSearchList = new Dictionary<string, Warehouse_IO.WHIO.Model.Dimension>();

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
            dimensionList.Sort((x, y) => x.GetM3().CompareTo(y.GetM3()));
            uomList.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));

            UoMListBox.Items.Clear();
            dimensionListBox.Items.Clear();

            foreach (Warehouse_IO.WHIO.Model.Dimension dimension in dimensionList)
            {
                int dimensionId = dimension.ID;
                string formattedDimension = $"{dimension.GetM3()} // {dimension.Unit.Name} {dimension.Name}";
                dimensionListBox.Items.Add(formattedDimension);

                dimensionforSearchList[formattedDimension] = dimension;
            }
            foreach (UOM uom in uomList)
            {
                string formattedUOM = $"{uom.Quantity}{uom.Unit.Name}/{uom.Package.Name} {uom.Name}";
                UoMListBox.Items.Add(formattedUOM);

                uomforSearchList[formattedUOM] = uom;
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
                string selectedUOMName = (string)UoMListBox.SelectedItem;
                if(uomforSearchList.ContainsKey(selectedUOMName))
                {
                    UOM selectedUOM = uomforSearchList[selectedUOMName];
                    int selectedID = selectedUOM.ID;

                    uom = new UOM(selectedID);
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
                    Warehouse_IO.WHIO.Model.Dimension selectedDimension = dimensionforSearchList[selectedDimensionName];
                    int selectedID = selectedDimension.ID;

                    dimension = new WHIO.Model.Dimension(selectedID);
                }
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

            foreach (UOM item in uomList)
            {
                string formattedDimension = $"{item.Quantity}{item.Unit.Name}/{item.Package.Name} {item.Name}";
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

            foreach (Warehouse_IO.WHIO.Model.Dimension item in dimensionList)
            {
                string formattedDimension = $"{item.GetM3()} // {item.Unit.Name} {item.Name}";
                if (formattedDimension.ToLower().Contains(searchText))
                {
                    dimensionListBox.Items.Add(formattedDimension);
                }
            }
        }
    }
}

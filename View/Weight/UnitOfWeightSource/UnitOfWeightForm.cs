using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.Control;

namespace Warehouse_IO.View.Weight.UnitOfWeightSource
{
    public partial class UnitOfWeightForm : Form
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<UnitOfUOMForGetList> unitOfW;
        BindingSource uBind;
        public event EventHandler returnMain;

        public UnitOfWeightForm()
        {
            InitializeComponent();
            unitOfW = new List<UnitOfUOMForGetList>();
            UpdateDatagridView();
            main = new MainForm();
        }

        private void UnitOfWeight_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            unitOfW = UnitOfUOMForGetList.GetUnitOfUOM();
            uBind = new BindingSource(unitOfW, null);
            unitOfW.Sort((x, y) => x.Name.CompareTo(y.Name));
            UnitOfUOMGridView.DataSource = uBind;
        }

        private void dataGridView_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkeyName = null;
                DataGridViewRow row = UnitOfUOMGridView.Rows[e.RowIndex];
                Global.tempPkeyName = row.Cells[0].Value.ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateDatagridView();
        }
    }
}

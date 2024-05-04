using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.Dimension.UnitOfVolumeSource
{
    public partial class UnitOfVolumeForm : Form
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<UnitOfDimension> unitOfDi;
        BindingSource uBind;
        public event EventHandler returnMain;

        public UnitOfVolumeForm()
        {
            InitializeComponent();
            unitOfDi = new List<UnitOfDimension>();
            UpdateDatagridView();
            main = new MainForm();
        }

        private void UnitOfVolume_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            unitOfDi = UnitOfDimension.GetUnitOfDimension();
            uBind = new BindingSource(unitOfDi, null);
            unitOfDi.Sort((x, y) => x.Name.CompareTo(y.Name));
            UnitOfDiGridView.DataSource = uBind;
        }

        private void dataGridView_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkeyName = null;
                DataGridViewRow row = UnitOfDiGridView.Rows[e.RowIndex];
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

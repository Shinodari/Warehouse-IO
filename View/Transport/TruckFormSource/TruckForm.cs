using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.Transport.TruckFormSource;

namespace Warehouse_IO.View.TruckFormSource
{
    public partial class TruckForm : Form
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<Truck> truck;
        BindingSource truckBind;
        public event EventHandler returnMain;

        public TruckForm()
        {
            InitializeComponent();
            truck = new List<Truck>();
            UpdateTruckDatagridView();
            main = new MainForm();
        }

        private void TruckForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateTruckDatagridView()
        {
            truck = Truck.GetTruckList();
            truckBind = new BindingSource(truck, null);
            truck.Sort((x, y) => x.ID.CompareTo(y.ID));
            truckGridView.DataSource = truck;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkey = -1;
                DataGridViewRow row = truckGridView.Rows[e.RowIndex];
                Global.tempPkey = (int)row.Cells[0].Value;
            }
        }

        private void addTruckButton_Click(object sender, EventArgs e)
        {
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }

        private void editTruckButton_Click(object sender, EventArgs e)
        {
            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void removeTruckButton_Click(object sender, EventArgs e)
        {
            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.ShowDialog();
        }

        private void exitTruckButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateTruckDatagridView();
        }
    }
}

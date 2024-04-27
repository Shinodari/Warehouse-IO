using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.TruckFormSource
{
    public partial class TruckForm : Form
    {
        private AddTruck addTruckWindow;
        private EditTruck editTruckWindow;
        private RemoveTruck removetruckWindow;

        List<Truck> truck;
        BindingSource truckBind;
        public event EventHandler returnMain;

        public TruckForm()
        {
            InitializeComponent();
            truck = new List<Truck>();
            UpdateTruckDatagridView();
        }

        private void TruckForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateTruckDatagridView()
        {
            truck = Truck.GetTruckList();
            truckBind = new BindingSource(truck, null);
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
            addTruckWindow = new AddTruck();
            addTruckWindow.Enabled = true;
            int x = (this.Width - addTruckWindow.Width) / 2;
            int y = (this.Height - addTruckWindow.Height) / 2;
            addTruckWindow.Location = new Point(x, y);

            addTruckWindow.UpdateGrid += OnUpdate;
            addTruckWindow.Closed += OnClosed;

            Controls.Add(addTruckWindow);
            addTruckWindow.BringToFront();
            truckGridView.Enabled = false;
        }

        private void editTruckButton_Click(object sender, EventArgs e)
        {
            editTruckWindow = new EditTruck();
            editTruckWindow.Enabled = true;
            int x = (this.Width - editTruckWindow.Width) / 2;
            int y = (this.Height - editTruckWindow.Height) / 2;
            editTruckWindow.Location = new Point(x, y);

            editTruckWindow.UpdateGrid += OnUpdate;
            editTruckWindow.Closed += OnClosed;

            Controls.Add(editTruckWindow);
            editTruckWindow.BringToFront();
            truckGridView.Enabled = false;
        }

        private void removeTruckButton_Click(object sender, EventArgs e)
        {
            removetruckWindow = new RemoveTruck();
            removetruckWindow.Enabled = true;
            int x = (this.Width - removetruckWindow.Width) / 2;
            int y = (this.Height - removetruckWindow.Height) / 2;
            removetruckWindow.Location = new Point(x, y);

            removetruckWindow.UpdateGrid += OnUpdate;
            removetruckWindow.Closed += OnClosed;

            Controls.Add(removetruckWindow);
            removetruckWindow.BringToFront();
            truckGridView.Enabled = false;
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
        private void OnClosed(object sender, EventArgs e)
        {
            truckGridView.Enabled = true;
        }
    }
}

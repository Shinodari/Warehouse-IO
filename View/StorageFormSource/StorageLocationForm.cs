using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.StorageFormSource;

namespace Warehouse_IO.View
{
    public partial class StorageLocationForm : Form
    {
        private AddStorage addStorageWindow;
        private EditStorage editStorageWindow;
        private RemoveStorage removeStorageWindow;

        List<Storage> sto;
        BindingSource stoBind;
        public event EventHandler returnMain;

        public StorageLocationForm()
        {
            InitializeComponent();
            sto = new List<Storage>();
            UpdateDepDatagridView();
        }
        private void StorageLocationForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDepDatagridView()
        {
            sto = Storage.GetStorage();
            stoBind = new BindingSource(sto, null);
            stoGridView.DataSource = stoBind;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkey = -1;
                DataGridViewRow row = stoGridView.Rows[e.RowIndex];
                Global.tempPkey = (int)row.Cells[0].Value;
            }
        }

        private void addStoButton_Click(object sender, EventArgs e)
        {
            addStorageWindow = new AddStorage();
            addStorageWindow.Enabled = true;
            int x = (this.Width - addStorageWindow.Width) / 2;
            int y = (this.Height - addStorageWindow.Height) / 2;
            addStorageWindow.Location = new Point(x, y);

            addStorageWindow.UpdateGrid += OnUpdate;
            addStorageWindow.Closed += OnClosed;

            Controls.Add(addStorageWindow);
            addStorageWindow.BringToFront();
            stoGridView.Enabled = false;
        }

        private void editStoButton_Click(object sender, EventArgs e)
        {
            editStorageWindow = new EditStorage();
            editStorageWindow.Enabled = true;
            int x = (this.Width - editStorageWindow.Width) / 2;
            int y = (this.Height - editStorageWindow.Height) / 2;
            editStorageWindow.Location = new Point(x, y);

            editStorageWindow.UpdateGrid += OnUpdate;
            editStorageWindow.Closed += OnClosed;

            Controls.Add(editStorageWindow);
            editStorageWindow.BringToFront();
            stoGridView.Enabled = false;
        }

        private void removeStoButton_Click(object sender, EventArgs e)
        {
            removeStorageWindow = new RemoveStorage();
            removeStorageWindow.Enabled = true;
            int x = (this.Width - removeStorageWindow.Width) / 2;
            int y = (this.Height - removeStorageWindow.Height) / 2;
            removeStorageWindow.Location = new Point(x, y);

            removeStorageWindow.UpdateGrid += OnUpdate;
            removeStorageWindow.Closed += OnClosed;

            Controls.Add(removeStorageWindow);
            removeStorageWindow.BringToFront();
            stoGridView.Enabled = false;
        }

        private void exitStoButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateDepDatagridView();
        }
        private void OnClosed(object sender, EventArgs e)
        {
            stoGridView.Enabled = true;
        }
    }
}

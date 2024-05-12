using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.StorageFormSource;

namespace Warehouse_IO.View
{
    public partial class StorageLocationForm : Form
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<Storage> sto;
        BindingSource stoBind;
        public event EventHandler returnMain;

        public StorageLocationForm()
        {
            InitializeComponent();
            sto = new List<Storage>();
            UpdateDepDatagridView();
            main = new MainForm();
        }
        private void StorageLocationForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        public void UpdateDepDatagridView()
        {
            sto = Storage.GetStorage();
            stoBind = new BindingSource(sto, null);
            sto.Sort((x, y) => x.ID.CompareTo(y.ID));
            stoGridView.DataSource = stoBind;
        }

        private void addStoButton_Click(object sender, EventArgs e)
        {
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }

        private void editStoButton_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = stoGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;
            Global.tempPkey = value;

            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void removeStoButton_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = stoGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;
            Global.tempPkey = value;

            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.ShowDialog();
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
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View.ParentFormComponents;
using Warehouse_IO.Control;

namespace Warehouse_IO.View.DeliveryplaceSource
{
    public partial class DeliveryplaceForm : ParentForm
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<DeliveryplaceForGetList> deliveryplaceList;
        BindingSource bind;
        public event EventHandler returnMain;

        public DeliveryplaceForm()
        {
            InitializeComponent();
            deliveryplaceList = new List<DeliveryplaceForGetList>();
            main = new MainForm();

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            UpdateDatagridView();
        }
        private void DeliveryplaceForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void UpdateDatagridView()
        {
            deliveryplaceList = DeliveryplaceForGetList.GetDeliveryplaceList();
            bind = new BindingSource(deliveryplaceList, null);
            deliveryplaceList.Sort((x, y) => x.Name.CompareTo(y.Name));
            dataGridView.DataSource = bind;
        }

        private void a_Click(object sender, EventArgs e)
        {
            add = new DeliveryplaceSource.Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }
        private void e_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;
            Global.tempPkey = value;

            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void r_Click(object sender, EventArgs e)
        {
            Global.tempPkey = -1;
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            int value = (int)selectedRow.Cells[0].Value;
            Global.tempPkey = value;

            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.ShowDialog();
        }

        private void x_Click(object sender, EventArgs e)
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

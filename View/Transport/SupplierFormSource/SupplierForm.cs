using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehouse_IO.Control;
using Warehouse_IO.Common;
using Warehouse_IO.View.Transport.SupplierFormSource;

namespace Warehouse_IO.View.SupplierFormSource
{
    public partial class SupplierForm : Form
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<SupplierForGetList> sup;
        BindingSource supBind;
        public event EventHandler returnMain;

        public SupplierForm()
        {
            InitializeComponent();
            sup = new List<SupplierForGetList>();
            UpdateSupDatagridView();
            main = new MainForm();
        }
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateSupDatagridView()
        {
            sup = SupplierForGetList.GetSupplierList();
            supBind = new BindingSource(sup, null);
            sup.Sort((x, y) => x.ID.CompareTo(y.ID));
            supGridView.DataSource = sup;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkey = -1;
                DataGridViewRow row = supGridView.Rows[e.RowIndex];
                Global.tempPkey = (int)row.Cells[0].Value;
            }
        }

        private void addSupButton_Click(object sender, EventArgs e)
        {
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.ShowDialog();
        }

        private void editSupButton_Click(object sender, EventArgs e)
        {
            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.ShowDialog();
        }

        private void removeSupButton_Click(object sender, EventArgs e)
        {
            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.ShowDialog();
        }

        private void exitSupButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateSupDatagridView();
        }
    }


}

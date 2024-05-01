﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
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

        List<Supplier> sup;
        BindingSource supBind;
        public event EventHandler returnMain;

        public SupplierForm()
        {
            InitializeComponent();
            sup = new List<Supplier>();
            UpdateSupDatagridView();
            main = new MainForm();
        }
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateSupDatagridView()
        {
            sup = Supplier.GetSupplierList();
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
            add.Shown += (s, ev) => CenterChildForm(add);
            add.ShowDialog();
        }

        private void editSupButton_Click(object sender, EventArgs e)
        {
            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.Shown += (s, ev) => CenterChildForm(add);
            edit.ShowDialog();
        }

        private void removeSupButton_Click(object sender, EventArgs e)
        {
            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.Shown += (s, ev) => CenterChildForm(add);
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
        private void CenterChildForm(Form childForm)
        {
            if (childForm != null && childForm.Owner != null)
            {
                int x = childForm.Owner.Left + (childForm.Owner.Width - childForm.Width) / 2;
                int y = childForm.Owner.Top + (childForm.Owner.Height - childForm.Height) / 2;
                childForm.Location = new Point(x, y);
            }
        }
        private void ParentForm_LocationChanged(object sender, EventArgs e)
        {
            if (add != null && add.Owner != null)
            {
                CenterChildForm(add);
            }
        }
    }


}

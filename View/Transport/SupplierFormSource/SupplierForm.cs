using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.SupplierFormSource
{
    public partial class SupplierForm : Form
    {
        private AddSup addSupWindow;
        private EditSup editSupWindow;
        private RemoveSup removeSupWindow;

        List<Supplier> sup;
        BindingSource supBind;
        public event EventHandler returnMain;

        public SupplierForm()
        {
            InitializeComponent();
            sup = new List<Supplier>();
            UpdateSupDatagridView();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateSupDatagridView()
        {
            sup = Supplier.GetSupplierList();
            supBind = new BindingSource(sup, null);
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
            addSupWindow = new AddSup();
            addSupWindow.Enabled = true;
            int x = (this.Width - addSupWindow.Width) / 2;
            int y = (this.Height - addSupWindow.Height) / 2;
            addSupWindow.Location = new Point(x, y);

            addSupWindow.UpdateGrid += OnUpdate;
            addSupWindow.Closed += OnClosed;

            Controls.Add(addSupWindow);
            addSupWindow.BringToFront();
            supGridView.Enabled = false;
        }

        private void editSupButton_Click(object sender, EventArgs e)
        {
            editSupWindow = new EditSup();
            editSupWindow.Enabled = true;
            int x = (this.Width - editSupWindow.Width) / 2;
            int y = (this.Height - editSupWindow.Height) / 2;
            editSupWindow.Location = new Point(x, y);

            editSupWindow.UpdateGrid += OnUpdate;
            editSupWindow.Closed += OnClosed;

            Controls.Add(editSupWindow);
            editSupWindow.BringToFront();
            supGridView.Enabled = false;
        }

        private void removeSupButton_Click(object sender, EventArgs e)
        {
            removeSupWindow = new RemoveSup();
            removeSupWindow.Enabled = true;
            int x = (this.Width - removeSupWindow.Width) / 2;
            int y = (this.Height - removeSupWindow.Height) / 2;
            removeSupWindow.Location = new Point(x, y);

            removeSupWindow.UpdateGrid += OnUpdate;
            removeSupWindow.Closed += OnClosed;

            Controls.Add(removeSupWindow);
            removeSupWindow.BringToFront();
            supGridView.Enabled = false;
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
        private void OnClosed(object sender, EventArgs e)
        {
            supGridView.Enabled = true;
        }
    }


}

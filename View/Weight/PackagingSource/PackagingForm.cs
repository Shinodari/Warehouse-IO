using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;


namespace Warehouse_IO.View.Weight.PackagingSource
{
    public partial class PackagingForm : Form
    {
        private AddPackage addPack;
        private EditPackage editPack;
        private RemovePackage removePack;

        List<Package> packlist;
        BindingSource bind;
        public event EventHandler returnMain;

        public PackagingForm()
        {
            InitializeComponent();
            packlist = new List<Package>();
            UpdateDatagridView();
        }

        private void Packaging_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            packlist = Package.GetPackageList();
            bind = new BindingSource(packlist, null);
            DataGridView.DataSource = bind;
        }

        private void dataGridView_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkeyName = null;
                DataGridViewRow row = DataGridView.Rows[e.RowIndex];
                Global.tempPkeyName = row.Cells[0].Value.ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addPack = new AddPackage();
            addPack.Enabled = true;
            int x = (this.Width - addPack.Width) / 2;
            int y = (this.Height - addPack.Height) / 2;
            addPack.Location = new Point(x, y);

            addPack.UpdateGrid += OnUpdate;
            addPack.Closed += OnClosed;

            Controls.Add(addPack);
            addPack.BringToFront();
            DataGridView.Enabled = false;
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            editPack = new EditPackage();
            editPack.Enabled = true;
            int x = (this.Width - editPack.Width) / 2;
            int y = (this.Height - editPack.Height) / 2;
            editPack.Location = new Point(x, y);

            editPack.UpdateGrid += OnUpdate;
            editPack.Closed += OnClosed;

            Controls.Add(editPack);
            editPack.BringToFront();
            DataGridView.Enabled = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            removePack = new RemovePackage();
            removePack.Enabled = true;
            int x = (this.Width - removePack.Width) / 2;
            int y = (this.Height - removePack.Height) / 2;
            removePack.Location = new Point(x, y);

            removePack.UpdateGrid += OnUpdate;
            removePack.Closed += OnClosed;

            Controls.Add(removePack);
            removePack.BringToFront();
            DataGridView.Enabled = false;
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
        private void OnClosed(object sender, EventArgs e)
        {
            DataGridView.Enabled = true;
        }
    }
}

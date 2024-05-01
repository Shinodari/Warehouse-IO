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
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<Package> packlist;
        BindingSource bind;
        public event EventHandler returnMain;

        public PackagingForm()
        {
            InitializeComponent();
            packlist = new List<Package>();
            UpdateDatagridView();
            main = new MainForm();
        }

        private void Packaging_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            packlist = Package.GetPackageList();
            bind = new BindingSource(packlist, null);
            packlist.Sort((x, y) => x.Name.CompareTo(y.Name));
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
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.Shown += (s, ev) => CenterChildForm(add);
            add.ShowDialog();
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.Shown += (s, ev) => CenterChildForm(add);
            edit.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.Shown += (s, ev) => CenterChildForm(add);
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

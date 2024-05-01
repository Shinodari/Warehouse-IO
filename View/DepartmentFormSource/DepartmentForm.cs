using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View.DepartmentFormSource;

namespace Warehouse_IO
{
    public partial class DepartmentForm : Form
    {
        private Add add;
        private Edit edit;
        private Remove remove;
        MainForm main;

        List<Department> dep;
        BindingSource depBind;
        public event EventHandler returnMain;

        public DepartmentForm()
        {
            InitializeComponent();
            dep = new List<Department>();
            UpdateDepDatagridView();
            main = new MainForm();
        }
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDepDatagridView()
        {
            dep = Department.GetDepartmentList();
            depBind = new BindingSource(dep, null);
            dep.Sort((x, y) => x.ID.CompareTo(y.ID));
            depGridView.DataSource = depBind;
        }

        private void dataGridView_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkey = -1;
                DataGridViewRow row = depGridView.Rows[e.RowIndex];
                Global.tempPkey = (int)row.Cells[0].Value;
            }
        }

        private void addDepButton(object sender, EventArgs e)
        {
            add = new Add();
            add.Owner = main;

            add.UpdateGrid += OnUpdate;
            add.Shown += (s, ev) => CenterChildForm(add);
            add.ShowDialog();
        }
        private void editDepButton(object sender, EventArgs e)
        {
            edit = new Edit();
            edit.Owner = main;

            edit.UpdateGrid += OnUpdate;
            edit.Shown += (s, ev) => CenterChildForm(add);
            edit.ShowDialog();
        }
        private void removeDepButton(object sender, EventArgs e)
        {
            remove = new Remove();
            remove.Owner = main;

            remove.UpdateGrid += OnUpdate;
            remove.Shown += (s, ev) => CenterChildForm(add);
            remove.ShowDialog();
        }
        private void exitDepButton(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
        
        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateDepDatagridView();
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

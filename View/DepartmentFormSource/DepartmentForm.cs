using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;
using Warehouse_IO.View;

namespace Warehouse_IO
{
    public partial class DepartmentForm : Form
    {
        private AddDep addDepWindow;
        private EditDep editDepWindow;
        private RemoveDep removeDepWindow;

        List<Department> dep;
        BindingSource depBind;
        public event EventHandler returnMain;

        public DepartmentForm()
        {
            InitializeComponent();
            dep = new List<Department>();
            UpdateDepDatagridView();
        }
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDepDatagridView()
        {
            dep = Department.GetDepartmentList();
            depBind = new BindingSource(dep, null);
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
            addDepWindow = new AddDep();
            addDepWindow.Enabled = true;
            int x = (this.Width - addDepWindow.Width) / 2;
            int y = (this.Height - addDepWindow.Height) / 2;
            addDepWindow.Location = new Point(x, y);

            addDepWindow.UpdateGrid += OnUpdate;
            addDepWindow.Closed += OnClosed;

            Controls.Add(addDepWindow);
            addDepWindow.BringToFront();
            depGridView.Enabled = false;
        }
        private void editDepButton(object sender, EventArgs e)
        {
            editDepWindow = new EditDep();
            editDepWindow.Enabled = true;
            int x = (this.Width - editDepWindow.Width) / 2;
            int y = (this.Height - editDepWindow.Height) / 2;
            editDepWindow.Location = new Point(x, y);

            editDepWindow.UpdateGrid += OnUpdate;
            editDepWindow.Closed += OnClosed;

            Controls.Add(editDepWindow);
            editDepWindow.BringToFront();
            depGridView.Enabled = false;
        }
        private void removeDepButton(object sender, EventArgs e)
        {
            removeDepWindow = new RemoveDep();
            removeDepWindow.Enabled = true;
            int x = (this.Width - removeDepWindow.Width) / 2;
            int y = (this.Height - removeDepWindow.Height) / 2;
            removeDepWindow.Location = new Point(x,y);

            removeDepWindow.UpdateGrid += OnUpdate;
            removeDepWindow.Closed += OnClosed;

            Controls.Add(removeDepWindow);
            removeDepWindow.BringToFront();
            depGridView.Enabled = false;
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
        private void OnClosed(object sender, EventArgs e)
        {
            depGridView.Enabled = true;
        }
    }
}

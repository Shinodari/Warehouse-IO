﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.Weight.UnitOfWeightSource
{
    public partial class UnitOfWeightForm : Form
    {
        private AddUnitOfWeight addUnit;
        private EditUnitOfWeight editUnit;
        private RemoveUnitOfWeight removeUnit;

        List<UnitOfUOM> unitOfW;
        BindingSource uBind;
        public event EventHandler returnMain;

        public UnitOfWeightForm()
        {
            InitializeComponent();
            unitOfW = new List<UnitOfUOM>();
            UpdateDatagridView();
        }

        private void UnitOfWeight_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void UpdateDatagridView()
        {
            unitOfW = UnitOfUOM.GetUnitOfUOM();
            uBind = new BindingSource(unitOfW, null);
            UnitOfDiGridView.DataSource = uBind;
        }

        private void dataGridView_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Global.tempPkeyName = null;
                DataGridViewRow row = UnitOfDiGridView.Rows[e.RowIndex];
                Global.tempPkeyName = row.Cells[0].Value.ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addUnit = new AddUnitOfWeight();
            addUnit.Enabled = true;
            int x = (this.Width - addUnit.Width) / 2;
            int y = (this.Height - addUnit.Height) / 2;
            addUnit.Location = new Point(x, y);

            addUnit.UpdateGrid += OnUpdate;
            addUnit.Closed += OnClosed;

            Controls.Add(addUnit);
            addUnit.BringToFront();
            UnitOfDiGridView.Enabled = false;
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            editUnit = new EditUnitOfWeight();
            editUnit.Enabled = true;
            int x = (this.Width - editUnit.Width) / 2;
            int y = (this.Height - editUnit.Height) / 2;
            editUnit.Location = new Point(x, y);

            editUnit.UpdateGrid += OnUpdate;
            editUnit.Closed += OnClosed;

            Controls.Add(editUnit);
            editUnit.BringToFront();
            UnitOfDiGridView.Enabled = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            removeUnit = new RemoveUnitOfWeight();
            removeUnit.Enabled = true;
            int x = (this.Width - removeUnit.Width) / 2;
            int y = (this.Height - removeUnit.Height) / 2;
            removeUnit.Location = new Point(x, y);

            removeUnit.UpdateGrid += OnUpdate;
            removeUnit.Closed += OnClosed;

            Controls.Add(removeUnit);
            removeUnit.BringToFront();
            UnitOfDiGridView.Enabled = false;
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
            UnitOfDiGridView.Enabled = true;
        }
    }
}

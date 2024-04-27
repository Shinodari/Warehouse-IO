﻿using System;
using Warehouse_IO.WHIO.Model;
using System.Windows.Forms;
using Warehouse_IO.Common;

namespace Warehouse_IO.View.TruckFormSource
{
    public partial class RemoveTruck : UserControl
    {
        Truck tRemove;

        public event EventHandler UpdateGrid;
        public event EventHandler Closed;

        public RemoveTruck()
        {
            InitializeComponent();
        }

        private void removeOKButton_Click(object sender, EventArgs e)
        {
            tRemove = new Truck(Global.tempPkey);
            if (tRemove.Remove())
            {
                MessageBox.Show(this, "Removed Success");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show(this, "It's foreign key");
        }

        private void removeCancle_Click(object sender, EventArgs e)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            this.Visible = false;
        }
    }
}
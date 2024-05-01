﻿using System;
using Warehouse_IO.WHIO.Model;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Transport.TruckFormSource
{
    public partial class Remove : RemoveForm
    {
        Truck remove;

        public event EventHandler UpdateGrid;


        public Remove()
        {
            InitializeComponent();
        }
        protected override void AttemptRemove()
        {
            remove = new Truck(Global.tempPkey);
            if (remove.Remove())
            {
                MessageBox.Show(this, "Removed Success");
                UpdateGrid?.Invoke(this, EventArgs.Empty);
                Close();
            }
            else MessageBox.Show(this, "It's foreign key");
        }
    }
}

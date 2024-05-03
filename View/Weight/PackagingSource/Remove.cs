﻿using System;
using Warehouse_IO.WHIO.Model;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View.Add_Edit_Remove_Components;

namespace Warehouse_IO.View.Weight.PackagingSource
{
    public partial class Remove : RemoveForm
    {
        Package remove;

        public event EventHandler UpdateGrid;

        public Remove()
        {
            InitializeComponent();
        }
        protected override void AttemptRemove()
        {
            remove = new WHIO.Model.Package(Global.tempPkeyName);
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
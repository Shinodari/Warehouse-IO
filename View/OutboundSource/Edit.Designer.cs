﻿namespace Warehouse_IO.View.OutboundSource
{
    partial class Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shipmentGroupBox.SuspendLayout();
            this.deliveryPlaceGroupBox.SuspendLayout();
            this.truckGroupBox.SuspendLayout();
            this.productGroupBox.SuspendLayout();
            this.exportShipmentGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createShipmentButton
            // 
            this.createShipmentButton.Click += new System.EventHandler(this.createShipmentButton_Click);
            // 
            // deliveryPlaceTextBox
            // 
            this.deliveryPlaceTextBox.TextChanged += new System.EventHandler(this.deliveryPlaceTextBox_TextChanged_1);
            // 
            // deliveryplaceListBox
            // 
            this.deliveryplaceListBox.DoubleClick += new System.EventHandler(this.deliveryplaceListBox_DoubleClick);
            // 
            // addPlaceButton
            // 
            this.addPlaceButton.Click += new System.EventHandler(this.addPlaceButton_Click);
            // 
            // removePlaceButton
            // 
            this.removePlaceButton.Click += new System.EventHandler(this.removePlaceButton_Click);
            // 
            // removeTruckButton
            // 
            this.removeTruckButton.Click += new System.EventHandler(this.removeTruckButton_Click);
            // 
            // editTruckQuantityButton
            // 
            this.editTruckQuantityButton.Click += new System.EventHandler(this.editTruckQuantityButton_Click);
            // 
            // quantityTruckTextBox
            // 
            this.quantityTruckTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantityTruckTextBox_KeyPress);
            // 
            // addButtonTruck
            // 
            this.addButtonTruck.Click += new System.EventHandler(this.addButtonTruck_Click);
            // 
            // removeProductButton
            // 
            this.removeProductButton.Click += new System.EventHandler(this.removeProductButton_Click);
            // 
            // editProductQuantityButton
            // 
            this.editProductQuantityButton.Click += new System.EventHandler(this.editProductQuantityButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // productQuantityTextBox
            // 
            this.productQuantityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.productQuantityTextBox_KeyPress);
            // 
            // doneButton
            // 
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // productNameSearchTextBox
            // 
            this.productNameSearchTextBox.TextChanged += new System.EventHandler(this.productNameSearchTextBox_TextChanged);
            // 
            // importFileButton
            // 
            this.importFileButton.Click += new System.EventHandler(this.importFileButton_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "Edit";
            this.Text = "Edit";
            this.shipmentGroupBox.ResumeLayout(false);
            this.shipmentGroupBox.PerformLayout();
            this.deliveryPlaceGroupBox.ResumeLayout(false);
            this.deliveryPlaceGroupBox.PerformLayout();
            this.truckGroupBox.ResumeLayout(false);
            this.truckGroupBox.PerformLayout();
            this.productGroupBox.ResumeLayout(false);
            this.productGroupBox.PerformLayout();
            this.exportShipmentGroupbox.ResumeLayout(false);
            this.exportShipmentGroupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
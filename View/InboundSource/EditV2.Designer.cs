namespace Warehouse_IO.View.InboundSource
{
    partial class EditV2
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
            this.truckGroupBox.SuspendLayout();
            this.productGroupBox.SuspendLayout();
            this.importShipmentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createShipmentButton
            // 
            this.createShipmentButton.Text = "Edit Shipment";
            this.createShipmentButton.Click += new System.EventHandler(this.createShipmentButton_Click);
            // 
            // addTruckButton
            // 
            this.addTruckButton.Click += new System.EventHandler(this.addTruckButton_Click);
            // 
            // quantityTruckTextBox
            // 
            this.quantityTruckTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantityTruckTextBox_KeyPress);
            // 
            // removeTruckButton
            // 
            this.removeTruckButton.Click += new System.EventHandler(this.removeTruckButton_Click);
            // 
            // editTruckQuantityButton
            // 
            this.editTruckQuantityButton.Click += new System.EventHandler(this.editTruckQuantityButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // productQuantityTextBox
            // 
            this.productQuantityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.productQuantityTextBox_KeyPress);
            // 
            // removeProductButton
            // 
            this.removeProductButton.Click += new System.EventHandler(this.removeProductButton_Click);
            // 
            // editProductQuantityButton
            // 
            this.editProductQuantityButton.Click += new System.EventHandler(this.editProductQuantityButton_Click);
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
            // importButton
            // 
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // createTruckButton
            // 
            this.createTruckButton.Click += new System.EventHandler(this.createTruckButton_Click);
            // 
            // createProductButton
            // 
            this.createProductButton.Click += new System.EventHandler(this.createProductButton_Click);
            // 
            // EditV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "EditV2";
            this.Text = "EditV2";
            this.shipmentGroupBox.ResumeLayout(false);
            this.shipmentGroupBox.PerformLayout();
            this.truckGroupBox.ResumeLayout(false);
            this.truckGroupBox.PerformLayout();
            this.productGroupBox.ResumeLayout(false);
            this.productGroupBox.PerformLayout();
            this.importShipmentGroupBox.ResumeLayout(false);
            this.importShipmentGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
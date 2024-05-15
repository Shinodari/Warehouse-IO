namespace Warehouse_IO.View.Add_Edit_Remove_Components
{
    partial class AddEdit_Inbound_Outbound_FormV2
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
            this.shipmentGroupBox = new System.Windows.Forms.GroupBox();
            this.importShipmentGroupBox = new System.Windows.Forms.GroupBox();
            this.IsInterCheckBox = new System.Windows.Forms.CheckBox();
            this.storageLocationLabel = new System.Windows.Forms.Label();
            this.createShipmentButton = new System.Windows.Forms.Button();
            this.deliveryDateLabel = new System.Windows.Forms.Label();
            this.invoiceLabel = new System.Windows.Forms.Label();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.deliveryDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.storageLocationComboBox = new System.Windows.Forms.ComboBox();
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.invoiceTextBox = new System.Windows.Forms.TextBox();
            this.truckGroupBox = new System.Windows.Forms.GroupBox();
            this.productQuantityLabel = new System.Windows.Forms.Label();
            this.removeTruckButton = new System.Windows.Forms.Button();
            this.editTruckQuantityButton = new System.Windows.Forms.Button();
            this.quantityTruckTextBox = new System.Windows.Forms.TextBox();
            this.addTruckButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.truckDataGridView = new System.Windows.Forms.DataGridView();
            this.truckListBox = new System.Windows.Forms.ListBox();
            this.truckLabel = new System.Windows.Forms.Label();
            this.productGroupBox = new System.Windows.Forms.GroupBox();
            this.productNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.removeProductButton = new System.Windows.Forms.Button();
            this.editProductQuantityButton = new System.Windows.Forms.Button();
            this.productListLabel = new System.Windows.Forms.Label();
            this.productListDatagridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.addProductButton = new System.Windows.Forms.Button();
            this.productQuantityTextBox = new System.Windows.Forms.TextBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.productListBox = new System.Windows.Forms.ListBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.shipmentGroupBox.SuspendLayout();
            this.importShipmentGroupBox.SuspendLayout();
            this.truckGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.truckDataGridView)).BeginInit();
            this.productGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productListDatagridView)).BeginInit();
            this.SuspendLayout();
            // 
            // shipmentGroupBox
            // 
            this.shipmentGroupBox.Controls.Add(this.importShipmentGroupBox);
            this.shipmentGroupBox.Controls.Add(this.storageLocationLabel);
            this.shipmentGroupBox.Controls.Add(this.createShipmentButton);
            this.shipmentGroupBox.Controls.Add(this.deliveryDateLabel);
            this.shipmentGroupBox.Controls.Add(this.invoiceLabel);
            this.shipmentGroupBox.Controls.Add(this.supplierLabel);
            this.shipmentGroupBox.Controls.Add(this.deliveryDatedateTimePicker);
            this.shipmentGroupBox.Controls.Add(this.storageLocationComboBox);
            this.shipmentGroupBox.Controls.Add(this.supplierComboBox);
            this.shipmentGroupBox.Controls.Add(this.invoiceTextBox);
            this.shipmentGroupBox.Location = new System.Drawing.Point(0, 0);
            this.shipmentGroupBox.Name = "shipmentGroupBox";
            this.shipmentGroupBox.Size = new System.Drawing.Size(995, 91);
            this.shipmentGroupBox.TabIndex = 50;
            this.shipmentGroupBox.TabStop = false;
            this.shipmentGroupBox.Text = "Shipment";
            // 
            // importShipmentGroupBox
            // 
            this.importShipmentGroupBox.Controls.Add(this.IsInterCheckBox);
            this.importShipmentGroupBox.Location = new System.Drawing.Point(622, 40);
            this.importShipmentGroupBox.Name = "importShipmentGroupBox";
            this.importShipmentGroupBox.Size = new System.Drawing.Size(265, 43);
            this.importShipmentGroupBox.TabIndex = 55;
            this.importShipmentGroupBox.TabStop = false;
            this.importShipmentGroupBox.Text = "Import Shipment";
            // 
            // IsInterCheckBox
            // 
            this.IsInterCheckBox.AutoSize = true;
            this.IsInterCheckBox.Location = new System.Drawing.Point(65, 19);
            this.IsInterCheckBox.Name = "IsInterCheckBox";
            this.IsInterCheckBox.Size = new System.Drawing.Size(145, 17);
            this.IsInterCheckBox.TabIndex = 14;
            this.IsInterCheckBox.Text = "Yes / If no, leave it blank";
            this.IsInterCheckBox.UseVisualStyleBackColor = true;
            // 
            // storageLocationLabel
            // 
            this.storageLocationLabel.AutoSize = true;
            this.storageLocationLabel.Location = new System.Drawing.Point(24, 45);
            this.storageLocationLabel.Name = "storageLocationLabel";
            this.storageLocationLabel.Size = new System.Drawing.Size(50, 13);
            this.storageLocationLabel.TabIndex = 53;
            this.storageLocationLabel.Text = "Storage :";
            // 
            // createShipmentButton
            // 
            this.createShipmentButton.Location = new System.Drawing.Point(893, 15);
            this.createShipmentButton.Name = "createShipmentButton";
            this.createShipmentButton.Size = new System.Drawing.Size(96, 55);
            this.createShipmentButton.TabIndex = 15;
            this.createShipmentButton.Text = "Create Shipment";
            this.createShipmentButton.UseVisualStyleBackColor = true;
            // 
            // deliveryDateLabel
            // 
            this.deliveryDateLabel.AutoSize = true;
            this.deliveryDateLabel.Location = new System.Drawing.Point(607, 17);
            this.deliveryDateLabel.Name = "deliveryDateLabel";
            this.deliveryDateLabel.Size = new System.Drawing.Size(77, 13);
            this.deliveryDateLabel.TabIndex = 54;
            this.deliveryDateLabel.Text = "Delivery Date :";
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.AutoSize = true;
            this.invoiceLabel.Location = new System.Drawing.Point(8, 18);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.Size = new System.Drawing.Size(65, 13);
            this.invoiceLabel.TabIndex = 52;
            this.invoiceLabel.Text = "Invoice No :";
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Location = new System.Drawing.Point(364, 15);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(51, 13);
            this.supplierLabel.TabIndex = 51;
            this.supplierLabel.Text = "Supplier :";
            // 
            // deliveryDatedateTimePicker
            // 
            this.deliveryDatedateTimePicker.Location = new System.Drawing.Point(687, 13);
            this.deliveryDatedateTimePicker.Name = "deliveryDatedateTimePicker";
            this.deliveryDatedateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.deliveryDatedateTimePicker.TabIndex = 13;
            // 
            // storageLocationComboBox
            // 
            this.storageLocationComboBox.FormattingEnabled = true;
            this.storageLocationComboBox.Location = new System.Drawing.Point(77, 41);
            this.storageLocationComboBox.Name = "storageLocationComboBox";
            this.storageLocationComboBox.Size = new System.Drawing.Size(148, 21);
            this.storageLocationComboBox.TabIndex = 12;
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(421, 12);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(148, 21);
            this.supplierComboBox.TabIndex = 10;
            // 
            // invoiceTextBox
            // 
            this.invoiceTextBox.Location = new System.Drawing.Point(76, 15);
            this.invoiceTextBox.Name = "invoiceTextBox";
            this.invoiceTextBox.Size = new System.Drawing.Size(148, 20);
            this.invoiceTextBox.TabIndex = 11;
            // 
            // truckGroupBox
            // 
            this.truckGroupBox.Controls.Add(this.productQuantityLabel);
            this.truckGroupBox.Controls.Add(this.removeTruckButton);
            this.truckGroupBox.Controls.Add(this.editTruckQuantityButton);
            this.truckGroupBox.Controls.Add(this.quantityTruckTextBox);
            this.truckGroupBox.Controls.Add(this.addTruckButton);
            this.truckGroupBox.Controls.Add(this.label1);
            this.truckGroupBox.Controls.Add(this.truckDataGridView);
            this.truckGroupBox.Controls.Add(this.truckListBox);
            this.truckGroupBox.Controls.Add(this.truckLabel);
            this.truckGroupBox.Location = new System.Drawing.Point(0, 473);
            this.truckGroupBox.Name = "truckGroupBox";
            this.truckGroupBox.Size = new System.Drawing.Size(893, 256);
            this.truckGroupBox.TabIndex = 200;
            this.truckGroupBox.TabStop = false;
            this.truckGroupBox.Text = "Truck Details";
            // 
            // productQuantityLabel
            // 
            this.productQuantityLabel.AutoSize = true;
            this.productQuantityLabel.Location = new System.Drawing.Point(22, 191);
            this.productQuantityLabel.Name = "productQuantityLabel";
            this.productQuantityLabel.Size = new System.Drawing.Size(52, 13);
            this.productQuantityLabel.TabIndex = 202;
            this.productQuantityLabel.Text = "Quantity :";
            // 
            // removeTruckButton
            // 
            this.removeTruckButton.Location = new System.Drawing.Point(787, 219);
            this.removeTruckButton.Name = "removeTruckButton";
            this.removeTruckButton.Size = new System.Drawing.Size(100, 23);
            this.removeTruckButton.TabIndex = 25;
            this.removeTruckButton.Text = "Remove";
            this.removeTruckButton.UseVisualStyleBackColor = true;
            // 
            // editTruckQuantityButton
            // 
            this.editTruckQuantityButton.Location = new System.Drawing.Point(421, 219);
            this.editTruckQuantityButton.Name = "editTruckQuantityButton";
            this.editTruckQuantityButton.Size = new System.Drawing.Size(100, 23);
            this.editTruckQuantityButton.TabIndex = 24;
            this.editTruckQuantityButton.Text = "Edit Quantity";
            this.editTruckQuantityButton.UseVisualStyleBackColor = true;
            // 
            // quantityTruckTextBox
            // 
            this.quantityTruckTextBox.Location = new System.Drawing.Point(77, 188);
            this.quantityTruckTextBox.Name = "quantityTruckTextBox";
            this.quantityTruckTextBox.Size = new System.Drawing.Size(148, 20);
            this.quantityTruckTextBox.TabIndex = 21;
            // 
            // addTruckButton
            // 
            this.addTruckButton.Location = new System.Drawing.Point(150, 219);
            this.addTruckButton.Name = "addTruckButton";
            this.addTruckButton.Size = new System.Drawing.Size(75, 23);
            this.addTruckButton.TabIndex = 22;
            this.addTruckButton.Text = "Add";
            this.addTruckButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 203;
            this.label1.Text = "Truck List :";
            // 
            // truckDataGridView
            // 
            this.truckDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.truckDataGridView.Location = new System.Drawing.Point(302, 12);
            this.truckDataGridView.MultiSelect = false;
            this.truckDataGridView.Name = "truckDataGridView";
            this.truckDataGridView.ReadOnly = true;
            this.truckDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.truckDataGridView.Size = new System.Drawing.Size(585, 196);
            this.truckDataGridView.TabIndex = 23;
            // 
            // truckListBox
            // 
            this.truckListBox.FormattingEnabled = true;
            this.truckListBox.Location = new System.Drawing.Point(76, 12);
            this.truckListBox.Name = "truckListBox";
            this.truckListBox.Size = new System.Drawing.Size(148, 173);
            this.truckListBox.TabIndex = 20;
            // 
            // truckLabel
            // 
            this.truckLabel.AutoSize = true;
            this.truckLabel.Location = new System.Drawing.Point(5, 19);
            this.truckLabel.Name = "truckLabel";
            this.truckLabel.Size = new System.Drawing.Size(68, 13);
            this.truckLabel.TabIndex = 201;
            this.truckLabel.Text = "Truck Type :";
            // 
            // productGroupBox
            // 
            this.productGroupBox.Controls.Add(this.importButton);
            this.productGroupBox.Controls.Add(this.productNameSearchTextBox);
            this.productGroupBox.Controls.Add(this.removeProductButton);
            this.productGroupBox.Controls.Add(this.editProductQuantityButton);
            this.productGroupBox.Controls.Add(this.productListLabel);
            this.productGroupBox.Controls.Add(this.productListDatagridView);
            this.productGroupBox.Controls.Add(this.label2);
            this.productGroupBox.Controls.Add(this.addProductButton);
            this.productGroupBox.Controls.Add(this.productQuantityTextBox);
            this.productGroupBox.Controls.Add(this.productLabel);
            this.productGroupBox.Controls.Add(this.productListBox);
            this.productGroupBox.Location = new System.Drawing.Point(0, 97);
            this.productGroupBox.Name = "productGroupBox";
            this.productGroupBox.Size = new System.Drawing.Size(996, 370);
            this.productGroupBox.TabIndex = 301;
            this.productGroupBox.TabStop = false;
            this.productGroupBox.Text = "Product Details";
            // 
            // productNameSearchTextBox
            // 
            this.productNameSearchTextBox.Location = new System.Drawing.Point(76, 22);
            this.productNameSearchTextBox.Name = "productNameSearchTextBox";
            this.productNameSearchTextBox.Size = new System.Drawing.Size(148, 20);
            this.productNameSearchTextBox.TabIndex = 305;
            // 
            // removeProductButton
            // 
            this.removeProductButton.Location = new System.Drawing.Point(787, 341);
            this.removeProductButton.Name = "removeProductButton";
            this.removeProductButton.Size = new System.Drawing.Size(100, 23);
            this.removeProductButton.TabIndex = 35;
            this.removeProductButton.Text = "Remove";
            this.removeProductButton.UseVisualStyleBackColor = true;
            // 
            // editProductQuantityButton
            // 
            this.editProductQuantityButton.Location = new System.Drawing.Point(421, 341);
            this.editProductQuantityButton.Name = "editProductQuantityButton";
            this.editProductQuantityButton.Size = new System.Drawing.Size(100, 23);
            this.editProductQuantityButton.TabIndex = 34;
            this.editProductQuantityButton.Text = "Edit Quantity";
            this.editProductQuantityButton.UseVisualStyleBackColor = true;
            // 
            // productListLabel
            // 
            this.productListLabel.AutoSize = true;
            this.productListLabel.Location = new System.Drawing.Point(230, 22);
            this.productListLabel.Name = "productListLabel";
            this.productListLabel.Size = new System.Drawing.Size(69, 13);
            this.productListLabel.TabIndex = 304;
            this.productListLabel.Text = "Product List :";
            // 
            // productListDatagridView
            // 
            this.productListDatagridView.AllowUserToResizeColumns = false;
            this.productListDatagridView.AllowUserToResizeRows = false;
            this.productListDatagridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productListDatagridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.productListDatagridView.Location = new System.Drawing.Point(302, 19);
            this.productListDatagridView.MultiSelect = false;
            this.productListDatagridView.Name = "productListDatagridView";
            this.productListDatagridView.ReadOnly = true;
            this.productListDatagridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productListDatagridView.Size = new System.Drawing.Size(688, 316);
            this.productListDatagridView.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 303;
            this.label2.Text = "Quantity :";
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(76, 341);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(62, 23);
            this.addProductButton.TabIndex = 32;
            this.addProductButton.Text = "Add";
            this.addProductButton.UseVisualStyleBackColor = true;
            // 
            // productQuantityTextBox
            // 
            this.productQuantityTextBox.Location = new System.Drawing.Point(76, 315);
            this.productQuantityTextBox.Name = "productQuantityTextBox";
            this.productQuantityTextBox.Size = new System.Drawing.Size(148, 20);
            this.productQuantityTextBox.TabIndex = 31;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(23, 22);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(50, 13);
            this.productLabel.TabIndex = 302;
            this.productLabel.Text = "Product :";
            // 
            // productListBox
            // 
            this.productListBox.FormattingEnabled = true;
            this.productListBox.Location = new System.Drawing.Point(76, 45);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(148, 264);
            this.productListBox.TabIndex = 30;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(900, 626);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(96, 55);
            this.doneButton.TabIndex = 40;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(899, 687);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 28);
            this.cancelButton.TabIndex = 41;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(150, 341);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 306;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // AddEdit_Inbound_Outbound_FormV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.productGroupBox);
            this.Controls.Add(this.truckGroupBox);
            this.Controls.Add(this.shipmentGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEdit_Inbound_Outbound_FormV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEdit_Inbound_Outbound_FormV2";
            this.shipmentGroupBox.ResumeLayout(false);
            this.shipmentGroupBox.PerformLayout();
            this.importShipmentGroupBox.ResumeLayout(false);
            this.importShipmentGroupBox.PerformLayout();
            this.truckGroupBox.ResumeLayout(false);
            this.truckGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.truckDataGridView)).EndInit();
            this.productGroupBox.ResumeLayout(false);
            this.productGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productListDatagridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox shipmentGroupBox;
        protected System.Windows.Forms.Label storageLocationLabel;
        protected System.Windows.Forms.Button createShipmentButton;
        protected System.Windows.Forms.Label deliveryDateLabel;
        protected System.Windows.Forms.Label invoiceLabel;
        protected System.Windows.Forms.Label supplierLabel;
        protected System.Windows.Forms.DateTimePicker deliveryDatedateTimePicker;
        protected System.Windows.Forms.ComboBox storageLocationComboBox;
        protected System.Windows.Forms.ComboBox supplierComboBox;
        protected System.Windows.Forms.TextBox invoiceTextBox;
        protected System.Windows.Forms.GroupBox truckGroupBox;
        protected System.Windows.Forms.Label truckLabel;
        protected System.Windows.Forms.ListBox truckListBox;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DataGridView truckDataGridView;
        protected System.Windows.Forms.GroupBox productGroupBox;
        protected System.Windows.Forms.Button addTruckButton;
        protected System.Windows.Forms.TextBox quantityTruckTextBox;
        protected System.Windows.Forms.Button removeTruckButton;
        protected System.Windows.Forms.Button editTruckQuantityButton;
        protected System.Windows.Forms.Label productQuantityLabel;
        protected System.Windows.Forms.Label productLabel;
        protected System.Windows.Forms.ListBox productListBox;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button addProductButton;
        protected System.Windows.Forms.TextBox productQuantityTextBox;
        protected System.Windows.Forms.Label productListLabel;
        protected System.Windows.Forms.DataGridView productListDatagridView;
        protected System.Windows.Forms.Button removeProductButton;
        protected System.Windows.Forms.Button editProductQuantityButton;
        protected System.Windows.Forms.Button doneButton;
        protected System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.GroupBox importShipmentGroupBox;
        protected System.Windows.Forms.CheckBox IsInterCheckBox;
        protected System.Windows.Forms.TextBox productNameSearchTextBox;
        protected System.Windows.Forms.Button importButton;
    }
}
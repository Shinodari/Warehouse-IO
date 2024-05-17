namespace Warehouse_IO.View.DepartmentFormSource
{
    partial class departmentAddStorage_Deliveryplace
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
            this.storageListBox = new System.Windows.Forms.ListBox();
            this.deliveryplaceListBox = new System.Windows.Forms.ListBox();
            this.storageLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addStorageButton = new System.Windows.Forms.Button();
            this.addDeliveryplaceButton = new System.Windows.Forms.Button();
            this.storageGridview = new System.Windows.Forms.DataGridView();
            this.DeliveryplaceGridview = new System.Windows.Forms.DataGridView();
            this.removeDeliveryplaceButton = new System.Windows.Forms.Button();
            this.removeStorageButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.deliveryPlaceTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.storageGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryplaceGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // storageListBox
            // 
            this.storageListBox.FormattingEnabled = true;
            this.storageListBox.Location = new System.Drawing.Point(8, 373);
            this.storageListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.storageListBox.Name = "storageListBox";
            this.storageListBox.Size = new System.Drawing.Size(283, 173);
            this.storageListBox.TabIndex = 20;
            this.storageListBox.DoubleClick += new System.EventHandler(this.storageListBox_DoubleClick);
            // 
            // deliveryplaceListBox
            // 
            this.deliveryplaceListBox.FormattingEnabled = true;
            this.deliveryplaceListBox.Location = new System.Drawing.Point(7, 31);
            this.deliveryplaceListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deliveryplaceListBox.Name = "deliveryplaceListBox";
            this.deliveryplaceListBox.Size = new System.Drawing.Size(359, 290);
            this.deliveryplaceListBox.TabIndex = 11;
            this.deliveryplaceListBox.DoubleClick += new System.EventHandler(this.deliveryplaceListBox_DoubleClick);
            this.deliveryplaceListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deliveryplaceListBox_KeyPress);
            // 
            // storageLabel
            // 
            this.storageLabel.AutoSize = true;
            this.storageLabel.Location = new System.Drawing.Point(5, 349);
            this.storageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.storageLabel.Name = "storageLabel";
            this.storageLabel.Size = new System.Drawing.Size(59, 13);
            this.storageLabel.TabIndex = 101;
            this.storageLabel.Text = "Storage list";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Delivery Place List";
            // 
            // addStorageButton
            // 
            this.addStorageButton.Location = new System.Drawing.Point(214, 550);
            this.addStorageButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addStorageButton.Name = "addStorageButton";
            this.addStorageButton.Size = new System.Drawing.Size(75, 30);
            this.addStorageButton.TabIndex = 21;
            this.addStorageButton.Text = "Add";
            this.addStorageButton.UseVisualStyleBackColor = true;
            this.addStorageButton.Click += new System.EventHandler(this.addStorageButton_Click);
            // 
            // addDeliveryplaceButton
            // 
            this.addDeliveryplaceButton.Location = new System.Drawing.Point(290, 332);
            this.addDeliveryplaceButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addDeliveryplaceButton.Name = "addDeliveryplaceButton";
            this.addDeliveryplaceButton.Size = new System.Drawing.Size(75, 30);
            this.addDeliveryplaceButton.TabIndex = 12;
            this.addDeliveryplaceButton.Text = "Add";
            this.addDeliveryplaceButton.UseVisualStyleBackColor = true;
            this.addDeliveryplaceButton.Click += new System.EventHandler(this.addDeliveryplaceButton_Click);
            // 
            // storageGridview
            // 
            this.storageGridview.AllowUserToAddRows = false;
            this.storageGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storageGridview.Location = new System.Drawing.Point(310, 373);
            this.storageGridview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.storageGridview.Name = "storageGridview";
            this.storageGridview.ReadOnly = true;
            this.storageGridview.RowTemplate.Height = 24;
            this.storageGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.storageGridview.Size = new System.Drawing.Size(282, 172);
            this.storageGridview.TabIndex = 22;
            this.storageGridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.storageGridview_CellDoubleClick);
            // 
            // DeliveryplaceGridview
            // 
            this.DeliveryplaceGridview.AllowUserToAddRows = false;
            this.DeliveryplaceGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeliveryplaceGridview.Location = new System.Drawing.Point(383, 31);
            this.DeliveryplaceGridview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeliveryplaceGridview.Name = "DeliveryplaceGridview";
            this.DeliveryplaceGridview.ReadOnly = true;
            this.DeliveryplaceGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeliveryplaceGridview.Size = new System.Drawing.Size(360, 289);
            this.DeliveryplaceGridview.TabIndex = 13;
            this.DeliveryplaceGridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeliveryplaceGridview_CellDoubleClick);
            // 
            // removeDeliveryplaceButton
            // 
            this.removeDeliveryplaceButton.Location = new System.Drawing.Point(668, 332);
            this.removeDeliveryplaceButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeDeliveryplaceButton.Name = "removeDeliveryplaceButton";
            this.removeDeliveryplaceButton.Size = new System.Drawing.Size(75, 30);
            this.removeDeliveryplaceButton.TabIndex = 14;
            this.removeDeliveryplaceButton.Text = "Remove";
            this.removeDeliveryplaceButton.UseVisualStyleBackColor = true;
            this.removeDeliveryplaceButton.Click += new System.EventHandler(this.removeDeliveryplaceButton_Click);
            // 
            // removeStorageButton
            // 
            this.removeStorageButton.Location = new System.Drawing.Point(517, 550);
            this.removeStorageButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeStorageButton.Name = "removeStorageButton";
            this.removeStorageButton.Size = new System.Drawing.Size(75, 30);
            this.removeStorageButton.TabIndex = 23;
            this.removeStorageButton.Text = "Remove";
            this.removeStorageButton.UseVisualStyleBackColor = true;
            this.removeStorageButton.Click += new System.EventHandler(this.removeStorageButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(665, 514);
            this.doneButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(78, 63);
            this.doneButton.TabIndex = 30;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // deliveryPlaceTextBox
            // 
            this.deliveryPlaceTextBox.Location = new System.Drawing.Point(162, 7);
            this.deliveryPlaceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deliveryPlaceTextBox.Name = "deliveryPlaceTextBox";
            this.deliveryPlaceTextBox.Size = new System.Drawing.Size(204, 20);
            this.deliveryPlaceTextBox.TabIndex = 10;
            this.deliveryPlaceTextBox.TextChanged += new System.EventHandler(this.deliveryPlaceTextBox_TextChanged);
            // 
            // departmentAddStorage_Deliveryplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.deliveryPlaceTextBox);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.removeStorageButton);
            this.Controls.Add(this.removeDeliveryplaceButton);
            this.Controls.Add(this.DeliveryplaceGridview);
            this.Controls.Add(this.storageGridview);
            this.Controls.Add(this.addDeliveryplaceButton);
            this.Controls.Add(this.addStorageButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.storageLabel);
            this.Controls.Add(this.deliveryplaceListBox);
            this.Controls.Add(this.storageListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "departmentAddStorage_Deliveryplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Storage & Delivery Place";
            ((System.ComponentModel.ISupportInitialize)(this.storageGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryplaceGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox storageListBox;
        private System.Windows.Forms.ListBox deliveryplaceListBox;
        private System.Windows.Forms.Label storageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addStorageButton;
        private System.Windows.Forms.Button addDeliveryplaceButton;
        private System.Windows.Forms.DataGridView storageGridview;
        private System.Windows.Forms.DataGridView DeliveryplaceGridview;
        private System.Windows.Forms.Button removeDeliveryplaceButton;
        private System.Windows.Forms.Button removeStorageButton;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.TextBox deliveryPlaceTextBox;
    }
}
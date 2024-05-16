namespace Warehouse_IO.View.In_Out_ActivityForm
{
    partial class ItemlistPerShipmentForm
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
            this.itemListDataGridView = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // itemListDataGridView
            // 
            this.itemListDataGridView.AllowUserToAddRows = false;
            this.itemListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemListDataGridView.Location = new System.Drawing.Point(16, 15);
            this.itemListDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.itemListDataGridView.MultiSelect = false;
            this.itemListDataGridView.Name = "itemListDataGridView";
            this.itemListDataGridView.ReadOnly = true;
            this.itemListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemListDataGridView.Size = new System.Drawing.Size(1160, 834);
            this.itemListDataGridView.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1076, 857);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 28);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // ItemlistPerShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 897);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.itemListDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemlistPerShipmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item List Details";
            ((System.ComponentModel.ISupportInitialize)(this.itemListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView itemListDataGridView;
        protected System.Windows.Forms.Button closeButton;
    }
}
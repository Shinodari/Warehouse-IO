namespace Warehouse_IO.View.Add_Edit_Remove_Components
{
    partial class AddEditUOMForm
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
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.unitOfWeightListBox = new System.Windows.Forms.ListBox();
            this.perPackageListBox = new System.Windows.Forms.ListBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.unitOfWeightLabel = new System.Windows.Forms.Label();
            this.perPackageLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(99, 24);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(133, 20);
            this.quantityTextBox.TabIndex = 0;
            // 
            // unitOfWeightListBox
            // 
            this.unitOfWeightListBox.FormattingEnabled = true;
            this.unitOfWeightListBox.Location = new System.Drawing.Point(99, 68);
            this.unitOfWeightListBox.Name = "unitOfWeightListBox";
            this.unitOfWeightListBox.Size = new System.Drawing.Size(133, 160);
            this.unitOfWeightListBox.TabIndex = 1;
            // 
            // perPackageListBox
            // 
            this.perPackageListBox.FormattingEnabled = true;
            this.perPackageListBox.Location = new System.Drawing.Point(342, 68);
            this.perPackageListBox.Name = "perPackageListBox";
            this.perPackageListBox.Size = new System.Drawing.Size(133, 160);
            this.perPackageListBox.TabIndex = 2;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(24, 27);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(52, 13);
            this.quantityLabel.TabIndex = 3;
            this.quantityLabel.Text = "Quantity :";
            // 
            // unitOfWeightLabel
            // 
            this.unitOfWeightLabel.AutoSize = true;
            this.unitOfWeightLabel.Location = new System.Drawing.Point(12, 68);
            this.unitOfWeightLabel.Name = "unitOfWeightLabel";
            this.unitOfWeightLabel.Size = new System.Drawing.Size(81, 13);
            this.unitOfWeightLabel.TabIndex = 4;
            this.unitOfWeightLabel.Text = "Unit of Weight :";
            // 
            // perPackageLabel
            // 
            this.perPackageLabel.AutoSize = true;
            this.perPackageLabel.Location = new System.Drawing.Point(248, 68);
            this.perPackageLabel.Name = "perPackageLabel";
            this.perPackageLabel.Size = new System.Drawing.Size(74, 13);
            this.perPackageLabel.TabIndex = 5;
            this.perPackageLabel.Text = "per Package :";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(319, 245);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(400, 245);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddEditUOMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 301);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.perPackageLabel);
            this.Controls.Add(this.unitOfWeightLabel);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.perPackageListBox);
            this.Controls.Add(this.unitOfWeightListBox);
            this.Controls.Add(this.quantityTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditUOMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditUOMForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox quantityTextBox;
        protected System.Windows.Forms.ListBox unitOfWeightListBox;
        protected System.Windows.Forms.ListBox perPackageListBox;
        protected System.Windows.Forms.Label quantityLabel;
        protected System.Windows.Forms.Label unitOfWeightLabel;
        protected System.Windows.Forms.Label perPackageLabel;
        protected System.Windows.Forms.Button addButton;
        protected System.Windows.Forms.Button cancelButton;
    }
}
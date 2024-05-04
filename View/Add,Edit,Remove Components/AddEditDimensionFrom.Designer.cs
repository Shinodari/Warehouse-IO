namespace Warehouse_IO.View.Add_Edit_Remove_Components
{
    partial class AddEditDimensionFrom
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
        protected void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.unitOfVolumeListBox = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.unitOfVolumeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(138, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(148, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(138, 38);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(148, 20);
            this.widthTextBox.TabIndex = 1;
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(138, 64);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(148, 20);
            this.lengthTextBox.TabIndex = 2;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(138, 90);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(148, 20);
            this.heightTextBox.TabIndex = 3;
            // 
            // unitOfVolumeListBox
            // 
            this.unitOfVolumeListBox.FormattingEnabled = true;
            this.unitOfVolumeListBox.Location = new System.Drawing.Point(138, 116);
            this.unitOfVolumeListBox.Name = "unitOfVolumeListBox";
            this.unitOfVolumeListBox.Size = new System.Drawing.Size(148, 160);
            this.unitOfVolumeListBox.TabIndex = 4;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(306, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(88, 20);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(306, 38);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 20);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(91, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name :";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(91, 41);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(41, 13);
            this.widthLabel.TabIndex = 8;
            this.widthLabel.Text = "Width :";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(86, 67);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(46, 13);
            this.lengthLabel.TabIndex = 9;
            this.lengthLabel.Text = "Length :";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(88, 93);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(44, 13);
            this.heightLabel.TabIndex = 10;
            this.heightLabel.Text = "Height :";
            // 
            // unitOfVolumeLabel
            // 
            this.unitOfVolumeLabel.AutoSize = true;
            this.unitOfVolumeLabel.Location = new System.Drawing.Point(50, 116);
            this.unitOfVolumeLabel.Name = "unitOfVolumeLabel";
            this.unitOfVolumeLabel.Size = new System.Drawing.Size(82, 13);
            this.unitOfVolumeLabel.TabIndex = 11;
            this.unitOfVolumeLabel.Text = "Unit of Volume :";
            // 
            // AddEditDimensionFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 296);
            this.ControlBox = false;
            this.Controls.Add(this.unitOfVolumeLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.unitOfVolumeListBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditDimensionFrom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditDimensionFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox nameTextBox;
        protected System.Windows.Forms.TextBox widthTextBox;
        protected System.Windows.Forms.TextBox lengthTextBox;
        protected System.Windows.Forms.TextBox heightTextBox;
        protected System.Windows.Forms.ListBox unitOfVolumeListBox;
        protected System.Windows.Forms.Button AddButton;
        protected System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.Label nameLabel;
        protected System.Windows.Forms.Label widthLabel;
        protected System.Windows.Forms.Label lengthLabel;
        protected System.Windows.Forms.Label heightLabel;
        protected System.Windows.Forms.Label unitOfVolumeLabel;
    }
}
﻿namespace Warehouse_IO.View.OutboundSource
{
    partial class EditQuantityWindow
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.EditTextBox = new System.Windows.Forms.TextBox();
            this.OKEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameLabel.Location = new System.Drawing.Point(12, 17);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(52, 13);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "Quantity :";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(204, 38);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(62, 23);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditTextBox
            // 
            this.EditTextBox.Location = new System.Drawing.Point(69, 14);
            this.EditTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EditTextBox.Name = "EditTextBox";
            this.EditTextBox.Size = new System.Drawing.Size(197, 20);
            this.EditTextBox.TabIndex = 10;
            this.EditTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditTextBox_KeyPress);
            // 
            // OKEdit
            // 
            this.OKEdit.Location = new System.Drawing.Point(138, 38);
            this.OKEdit.Margin = new System.Windows.Forms.Padding(2);
            this.OKEdit.Name = "OKEdit";
            this.OKEdit.Size = new System.Drawing.Size(62, 23);
            this.OKEdit.TabIndex = 11;
            this.OKEdit.Text = "OK";
            this.OKEdit.UseVisualStyleBackColor = true;
            this.OKEdit.Click += new System.EventHandler(this.OKEdit_Click);
            // 
            // EditQuantityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 75);
            this.ControlBox = false;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.EditTextBox);
            this.Controls.Add(this.OKEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditQuantityWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditQuantityWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label nameLabel;
        protected System.Windows.Forms.Button CancelButton;
        protected System.Windows.Forms.TextBox EditTextBox;
        protected System.Windows.Forms.Button OKEdit;
    }
}
﻿namespace Warehouse_IO.View.Add_Edit_Remove_Components
{
    partial class EditForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.EditTextBox = new System.Windows.Forms.TextBox();
            this.OKEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(94, 76);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(62, 50);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditTextBox
            // 
            this.EditTextBox.Location = new System.Drawing.Point(14, 34);
            this.EditTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EditTextBox.Name = "EditTextBox";
            this.EditTextBox.Size = new System.Drawing.Size(143, 20);
            this.EditTextBox.TabIndex = 6;
            // 
            // OKEdit
            // 
            this.OKEdit.Location = new System.Drawing.Point(14, 76);
            this.OKEdit.Margin = new System.Windows.Forms.Padding(2);
            this.OKEdit.Name = "OKEdit";
            this.OKEdit.Size = new System.Drawing.Size(62, 50);
            this.OKEdit.TabIndex = 5;
            this.OKEdit.Text = "OK";
            this.OKEdit.UseVisualStyleBackColor = true;
            this.OKEdit.Click += new System.EventHandler(this.OKEdit_Click);
            this.OKEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OKEdit_KeyPress);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 160);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.EditTextBox);
            this.Controls.Add(this.OKEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button CancelButton;
        protected System.Windows.Forms.TextBox EditTextBox;
        protected System.Windows.Forms.Button OKEdit;
    }
}
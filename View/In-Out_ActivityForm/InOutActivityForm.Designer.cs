﻿namespace Warehouse_IO.View.In_Out_ActivityForm
{
    partial class InOutActivityForm
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
            this.inboundDataGridView = new System.Windows.Forms.DataGridView();
            this.outboundDataGridView = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.inboundActivityLabel = new System.Windows.Forms.Label();
            this.outboundActivityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inboundDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outboundDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // inboundDataGridView
            // 
            this.inboundDataGridView.AllowUserToAddRows = false;
            this.inboundDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inboundDataGridView.Location = new System.Drawing.Point(16, 30);
            this.inboundDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inboundDataGridView.MultiSelect = false;
            this.inboundDataGridView.Name = "inboundDataGridView";
            this.inboundDataGridView.ReadOnly = true;
            this.inboundDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inboundDataGridView.Size = new System.Drawing.Size(1155, 389);
            this.inboundDataGridView.TabIndex = 0;
            this.inboundDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inboundDataGridView_CellDoubleClick);
            // 
            // outboundDataGridView
            // 
            this.outboundDataGridView.AllowUserToAddRows = false;
            this.outboundDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outboundDataGridView.Location = new System.Drawing.Point(16, 449);
            this.outboundDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outboundDataGridView.MultiSelect = false;
            this.outboundDataGridView.Name = "outboundDataGridView";
            this.outboundDataGridView.ReadOnly = true;
            this.outboundDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.outboundDataGridView.Size = new System.Drawing.Size(1155, 389);
            this.outboundDataGridView.TabIndex = 1;
            this.outboundDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outboundDataGridView_CellDoubleClick);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1032, 846);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(139, 32);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // inboundActivityLabel
            // 
            this.inboundActivityLabel.AutoSize = true;
            this.inboundActivityLabel.Location = new System.Drawing.Point(12, 10);
            this.inboundActivityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inboundActivityLabel.Name = "inboundActivityLabel";
            this.inboundActivityLabel.Size = new System.Drawing.Size(107, 17);
            this.inboundActivityLabel.TabIndex = 3;
            this.inboundActivityLabel.Text = "Inbound Activity";
            // 
            // outboundActivityLabel
            // 
            this.outboundActivityLabel.AutoSize = true;
            this.outboundActivityLabel.Location = new System.Drawing.Point(16, 430);
            this.outboundActivityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outboundActivityLabel.Name = "outboundActivityLabel";
            this.outboundActivityLabel.Size = new System.Drawing.Size(119, 17);
            this.outboundActivityLabel.TabIndex = 4;
            this.outboundActivityLabel.Text = "Outbound Activity";
            // 
            // InOutActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 892);
            this.ControlBox = false;
            this.Controls.Add(this.outboundActivityLabel);
            this.Controls.Add(this.inboundActivityLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.outboundDataGridView);
            this.Controls.Add(this.inboundDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InOutActivityForm";
            this.Text = "In - Out Activity";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InOutActivityForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inboundDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outboundDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inboundDataGridView;
        private System.Windows.Forms.DataGridView outboundDataGridView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label inboundActivityLabel;
        private System.Windows.Forms.Label outboundActivityLabel;
    }
}
﻿namespace Warehouse_IO.View.OutboundSource
{
    partial class OutboundForm
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
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.Click += new System.EventHandler(this.x_Click);
            // 
            // r
            // 
            this.r.Click += new System.EventHandler(this.r_Click);
            // 
            // e
            // 
            this.e.Click += new System.EventHandler(this.e_Click);
            // 
            // a
            // 
            this.a.Click += new System.EventHandler(this.a_Click);
            // 
            // OutboundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 523);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OutboundForm";
            this.Text = "Outbound";
            this.Load += new System.EventHandler(this.OutboundForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
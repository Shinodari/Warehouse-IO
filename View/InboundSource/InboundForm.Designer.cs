namespace Warehouse_IO.View.InboundSource
{
    partial class InboundForm
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
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
            this.a.Text = "New";
            this.a.Click += new System.EventHandler(this.a_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(518, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(261, 20);
            this.searchTextBox.TabIndex = 24;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // InboundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 721);
            this.Controls.Add(this.searchTextBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "InboundForm";
            this.Text = "Inbound";
            this.Load += new System.EventHandler(this.InboundForm_Load);
            this.Controls.SetChildIndex(this.a, 0);
            this.Controls.SetChildIndex(this.e, 0);
            this.Controls.SetChildIndex(this.r, 0);
            this.Controls.SetChildIndex(this.x, 0);
            this.Controls.SetChildIndex(this.searchTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
    }
}
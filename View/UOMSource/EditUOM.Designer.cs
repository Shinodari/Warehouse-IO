namespace Warehouse_IO.View.UOMSource
{
    partial class EditUOM
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
            // addButton
            // 
            this.addButton.Text = "Edit";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            this.addButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addButton_KeyPress);
            // 
            // cancelButton
            // 
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // EditUOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 268);
            this.Name = "EditUOM";
            this.Text = "EditUOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
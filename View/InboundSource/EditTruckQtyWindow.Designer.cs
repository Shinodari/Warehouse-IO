namespace Warehouse_IO.View.InboundSource
{
    partial class EditTruckQtyWindow
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
            // CancelButton
            // 
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditTextBox
            // 
            this.EditTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditTextBox_KeyPress);
            // 
            // OKEdit
            // 
            this.OKEdit.Click += new System.EventHandler(this.OKEdit_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Size = new System.Drawing.Size(29, 13);
            this.nameLabel.Text = "Qty :";
            // 
            // EditTruckQtyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 75);
            this.Name = "EditTruckQtyWindow";
            this.Text = "EditTruckQtyWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
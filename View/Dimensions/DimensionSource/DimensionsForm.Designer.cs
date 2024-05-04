namespace Warehouse_IO.View.Dimensions.DimensionSource
{
    partial class DimensionsForm
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
            // DimensionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 469);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "DimensionsForm";
            this.Text = "DimensionsForm";
            this.Load += new System.EventHandler(this.DimensionsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
namespace Warehouse_IO.View.ProductSource
{
    partial class ProductForm
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
            this.searchProductNameTextBox = new System.Windows.Forms.TextBox();
            this.productSearchLabel = new System.Windows.Forms.Label();
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
            // searchProductNameTextBox
            // 
            this.searchProductNameTextBox.Location = new System.Drawing.Point(535, 3);
            this.searchProductNameTextBox.Name = "searchProductNameTextBox";
            this.searchProductNameTextBox.Size = new System.Drawing.Size(244, 20);
            this.searchProductNameTextBox.TabIndex = 24;
            this.searchProductNameTextBox.TextChanged += new System.EventHandler(this.searchProductNameTextBox_TextChanged);
            // 
            // productSearchLabel
            // 
            this.productSearchLabel.AutoSize = true;
            this.productSearchLabel.Location = new System.Drawing.Point(411, 7);
            this.productSearchLabel.Name = "productSearchLabel";
            this.productSearchLabel.Size = new System.Drawing.Size(118, 13);
            this.productSearchLabel.TabIndex = 25;
            this.productSearchLabel.Text = "Search Product Name :";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 721);
            this.Controls.Add(this.productSearchLabel);
            this.Controls.Add(this.searchProductNameTextBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.Controls.SetChildIndex(this.a, 0);
            this.Controls.SetChildIndex(this.e, 0);
            this.Controls.SetChildIndex(this.r, 0);
            this.Controls.SetChildIndex(this.x, 0);
            this.Controls.SetChildIndex(this.searchProductNameTextBox, 0);
            this.Controls.SetChildIndex(this.productSearchLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchProductNameTextBox;
        private System.Windows.Forms.Label productSearchLabel;
    }
}
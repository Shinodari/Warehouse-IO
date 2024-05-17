namespace Warehouse_IO
{
    partial class DepartmentForm
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
            this.a = new System.Windows.Forms.Button();
            this.e = new System.Windows.Forms.Button();
            this.r = new System.Windows.Forms.Button();
            this.x = new System.Windows.Forms.Button();
            this.depGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.addStorage_DelplaceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.depGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(646, 27);
            this.a.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(96, 55);
            this.a.TabIndex = 20;
            this.a.Text = "Add";
            this.a.UseVisualStyleBackColor = true;
            this.a.Click += new System.EventHandler(this.addDepButton);
            // 
            // e
            // 
            this.e.Location = new System.Drawing.Point(646, 87);
            this.e.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(96, 55);
            this.e.TabIndex = 21;
            this.e.Text = "Edit";
            this.e.UseVisualStyleBackColor = true;
            this.e.Click += new System.EventHandler(this.editDepButton);
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(646, 147);
            this.r.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(96, 55);
            this.r.TabIndex = 22;
            this.r.Text = "Remove";
            this.r.UseVisualStyleBackColor = true;
            this.r.Click += new System.EventHandler(this.removeDepButton);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(647, 518);
            this.x.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(96, 55);
            this.x.TabIndex = 23;
            this.x.Text = "Exit";
            this.x.UseVisualStyleBackColor = true;
            this.x.Click += new System.EventHandler(this.exitDepButton);
            // 
            // depGridView
            // 
            this.depGridView.AllowUserToResizeColumns = false;
            this.depGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.depGridView.Location = new System.Drawing.Point(9, 28);
            this.depGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.depGridView.Name = "depGridView";
            this.depGridView.ReadOnly = true;
            this.depGridView.RowTemplate.Height = 24;
            this.depGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.depGridView.Size = new System.Drawing.Size(633, 546);
            this.depGridView.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Department List";
            // 
            // addStorage_DelplaceButton
            // 
            this.addStorage_DelplaceButton.Location = new System.Drawing.Point(647, 275);
            this.addStorage_DelplaceButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addStorage_DelplaceButton.Name = "addStorage_DelplaceButton";
            this.addStorage_DelplaceButton.Size = new System.Drawing.Size(96, 55);
            this.addStorage_DelplaceButton.TabIndex = 24;
            this.addStorage_DelplaceButton.Text = "Add Storage & Delivery Place";
            this.addStorage_DelplaceButton.UseVisualStyleBackColor = true;
            this.addStorage_DelplaceButton.Click += new System.EventHandler(this.addStorage_DelplaceButton_Click);
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 721);
            this.ControlBox = false;
            this.Controls.Add(this.addStorage_DelplaceButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depGridView);
            this.Controls.Add(this.x);
            this.Controls.Add(this.r);
            this.Controls.Add(this.e);
            this.Controls.Add(this.a);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Department";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DepartmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.depGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button a;
        private System.Windows.Forms.Button e;
        private System.Windows.Forms.Button r;
        private System.Windows.Forms.Button x;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView depGridView;
        private System.Windows.Forms.Button addStorage_DelplaceButton;
    }
}
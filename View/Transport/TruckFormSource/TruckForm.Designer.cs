namespace Warehouse_IO.View.TruckFormSource
{
    partial class TruckForm
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
            this.truckGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.Button();
            this.r = new System.Windows.Forms.Button();
            this.e = new System.Windows.Forms.Button();
            this.a = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.truckGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // truckGridView
            // 
            this.truckGridView.AllowUserToResizeColumns = false;
            this.truckGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.truckGridView.Location = new System.Drawing.Point(9, 28);
            this.truckGridView.Margin = new System.Windows.Forms.Padding(2);
            this.truckGridView.Name = "truckGridView";
            this.truckGridView.ReadOnly = true;
            this.truckGridView.RowTemplate.Height = 24;
            this.truckGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.truckGridView.Size = new System.Drawing.Size(541, 474);
            this.truckGridView.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "Truck List";
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(554, 447);
            this.x.Margin = new System.Windows.Forms.Padding(2);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(96, 55);
            this.x.TabIndex = 14;
            this.x.Text = "Exit";
            this.x.UseVisualStyleBackColor = true;
            this.x.Click += new System.EventHandler(this.exitTruckButton_Click);
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(554, 148);
            this.r.Margin = new System.Windows.Forms.Padding(2);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(96, 55);
            this.r.TabIndex = 13;
            this.r.Text = "Remove";
            this.r.UseVisualStyleBackColor = true;
            this.r.Click += new System.EventHandler(this.removeTruckButton_Click);
            // 
            // e
            // 
            this.e.Location = new System.Drawing.Point(554, 88);
            this.e.Margin = new System.Windows.Forms.Padding(2);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(96, 55);
            this.e.TabIndex = 12;
            this.e.Text = "Edit";
            this.e.UseVisualStyleBackColor = true;
            this.e.Click += new System.EventHandler(this.editTruckButton_Click);
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(554, 28);
            this.a.Margin = new System.Windows.Forms.Padding(2);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(96, 55);
            this.a.TabIndex = 11;
            this.a.Text = "Add";
            this.a.UseVisualStyleBackColor = true;
            this.a.Click += new System.EventHandler(this.addTruckButton_Click);
            // 
            // TruckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 511);
            this.ControlBox = false;
            this.Controls.Add(this.x);
            this.Controls.Add(this.r);
            this.Controls.Add(this.e);
            this.Controls.Add(this.a);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.truckGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TruckForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TruckForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TruckForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.truckGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView truckGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button x;
        private System.Windows.Forms.Button r;
        private System.Windows.Forms.Button e;
        private System.Windows.Forms.Button a;
    }
}
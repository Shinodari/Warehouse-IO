namespace Warehouse_IO.View
{
    partial class StorageLocationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.stoGridView = new System.Windows.Forms.DataGridView();
            this.x = new System.Windows.Forms.Button();
            this.r = new System.Windows.Forms.Button();
            this.e = new System.Windows.Forms.Button();
            this.a = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Storage Location List";
            // 
            // stoGridView
            // 
            this.stoGridView.AllowUserToResizeColumns = false;
            this.stoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stoGridView.Location = new System.Drawing.Point(9, 28);
            this.stoGridView.Margin = new System.Windows.Forms.Padding(2);
            this.stoGridView.Name = "stoGridView";
            this.stoGridView.ReadOnly = true;
            this.stoGridView.RowTemplate.Height = 24;
            this.stoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stoGridView.Size = new System.Drawing.Size(475, 474);
            this.stoGridView.TabIndex = 7;
            this.stoGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(508, 447);
            this.x.Margin = new System.Windows.Forms.Padding(2);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(96, 55);
            this.x.TabIndex = 11;
            this.x.Text = "Exit";
            this.x.UseVisualStyleBackColor = true;
            this.x.Click += new System.EventHandler(this.exitStoButton_Click);
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(508, 148);
            this.r.Margin = new System.Windows.Forms.Padding(2);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(96, 55);
            this.r.TabIndex = 10;
            this.r.Text = "Remove";
            this.r.UseVisualStyleBackColor = true;
            this.r.Click += new System.EventHandler(this.removeStoButton_Click);
            // 
            // e
            // 
            this.e.Location = new System.Drawing.Point(508, 88);
            this.e.Margin = new System.Windows.Forms.Padding(2);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(96, 55);
            this.e.TabIndex = 9;
            this.e.Text = "Edit";
            this.e.UseVisualStyleBackColor = true;
            this.e.Click += new System.EventHandler(this.editStoButton_Click);
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(508, 28);
            this.a.Margin = new System.Windows.Forms.Padding(2);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(96, 55);
            this.a.TabIndex = 8;
            this.a.Text = "Add";
            this.a.UseVisualStyleBackColor = true;
            this.a.Click += new System.EventHandler(this.addStoButton_Click);
            // 
            // StorageLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 489);
            this.ControlBox = false;
            this.Controls.Add(this.x);
            this.Controls.Add(this.r);
            this.Controls.Add(this.e);
            this.Controls.Add(this.a);
            this.Controls.Add(this.stoGridView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageLocationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Storage Location";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StorageLocationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button x;
        private System.Windows.Forms.Button r;
        private System.Windows.Forms.Button e;
        private System.Windows.Forms.Button a;
        private System.Windows.Forms.DataGridView stoGridView;
    }
}
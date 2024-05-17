namespace Warehouse_IO.View.Dimension.UnitOfVolumeSource
{
    partial class UnitOfVolumeForm
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
            this.x = new System.Windows.Forms.Button();
            this.r = new System.Windows.Forms.Button();
            this.e = new System.Windows.Forms.Button();
            this.a = new System.Windows.Forms.Button();
            this.UnitOfDiGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UnitOfDiGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(779, 655);
            this.x.Margin = new System.Windows.Forms.Padding(2);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(96, 55);
            this.x.TabIndex = 23;
            this.x.Text = "Exit";
            this.x.UseVisualStyleBackColor = true;
            this.x.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(779, 148);
            this.r.Margin = new System.Windows.Forms.Padding(2);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(96, 55);
            this.r.TabIndex = 22;
            this.r.Text = "Remove";
            this.r.UseVisualStyleBackColor = true;
            this.r.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // e
            // 
            this.e.Location = new System.Drawing.Point(779, 88);
            this.e.Margin = new System.Windows.Forms.Padding(2);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(96, 55);
            this.e.TabIndex = 21;
            this.e.Text = "Edit";
            this.e.UseVisualStyleBackColor = true;
            this.e.Click += new System.EventHandler(this.editButton_Click);
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(779, 28);
            this.a.Margin = new System.Windows.Forms.Padding(2);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(96, 55);
            this.a.TabIndex = 20;
            this.a.Text = "Add";
            this.a.UseVisualStyleBackColor = true;
            this.a.Click += new System.EventHandler(this.addButton_Click);
            // 
            // UnitOfDiGridView
            // 
            this.UnitOfDiGridView.AllowUserToResizeColumns = false;
            this.UnitOfDiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnitOfDiGridView.Location = new System.Drawing.Point(9, 28);
            this.UnitOfDiGridView.Margin = new System.Windows.Forms.Padding(2);
            this.UnitOfDiGridView.Name = "UnitOfDiGridView";
            this.UnitOfDiGridView.ReadOnly = true;
            this.UnitOfDiGridView.RowHeadersWidth = 10;
            this.UnitOfDiGridView.RowTemplate.Height = 24;
            this.UnitOfDiGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UnitOfDiGridView.Size = new System.Drawing.Size(766, 682);
            this.UnitOfDiGridView.TabIndex = 13;
            this.UnitOfDiGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Unit of Volume List";
            // 
            // UnitOfVolumeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 721);
            this.ControlBox = false;
            this.Controls.Add(this.x);
            this.Controls.Add(this.r);
            this.Controls.Add(this.e);
            this.Controls.Add(this.a);
            this.Controls.Add(this.UnitOfDiGridView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitOfVolumeForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UnitOfVolume";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UnitOfVolume_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UnitOfDiGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button x;
        private System.Windows.Forms.Button r;
        private System.Windows.Forms.Button e;
        private System.Windows.Forms.Button a;
        private System.Windows.Forms.DataGridView UnitOfDiGridView;
        private System.Windows.Forms.Label label1;
    }
}
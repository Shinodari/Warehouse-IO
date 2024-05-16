namespace Warehouse_IO
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.inbondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outbondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inOutActivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uOMSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uOMOfDimensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packagingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dimensionSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dimensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitOfDimensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inbondToolStripMenuItem,
            this.outbondToolStripMenuItem,
            this.inOutActivityToolStripMenuItem,
            this.toolStripMenuItem1,
            this.monitorSettingToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(130, 721);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // inbondToolStripMenuItem
            // 
            this.inbondToolStripMenuItem.Name = "inbondToolStripMenuItem";
            this.inbondToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.inbondToolStripMenuItem.Text = "Inbond";
            this.inbondToolStripMenuItem.Click += new System.EventHandler(this.click_Inbound);
            // 
            // outbondToolStripMenuItem
            // 
            this.outbondToolStripMenuItem.Name = "outbondToolStripMenuItem";
            this.outbondToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.outbondToolStripMenuItem.Text = "Outbond";
            this.outbondToolStripMenuItem.Click += new System.EventHandler(this.click_Outbound);
            // 
            // inOutActivityToolStripMenuItem
            // 
            this.inOutActivityToolStripMenuItem.Name = "inOutActivityToolStripMenuItem";
            this.inOutActivityToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.inOutActivityToolStripMenuItem.Text = "In - Out Activity";
            this.inOutActivityToolStripMenuItem.Click += new System.EventHandler(this.click_InOut);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 24);
            this.toolStripMenuItem1.Text = "_______________";
            // 
            // monitorSettingToolStripMenuItem
            // 
            this.monitorSettingToolStripMenuItem.Name = "monitorSettingToolStripMenuItem";
            this.monitorSettingToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.monitorSettingToolStripMenuItem.Text = "Monitor Setting";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.uOMSettingToolStripMenuItem,
            this.dimensionSettingToolStripMenuItem,
            this.transportSettingToolStripMenuItem,
            this.storageToolStripMenuItem,
            this.departmentToolStripMenuItem,
            this.userToolStripMenuItem,
            this.userToolStripMenuItem1});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.click_Product);
            // 
            // uOMSettingToolStripMenuItem
            // 
            this.uOMSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uOMToolStripMenuItem,
            this.uOMOfDimensionToolStripMenuItem,
            this.packagingToolStripMenuItem});
            this.uOMSettingToolStripMenuItem.Name = "uOMSettingToolStripMenuItem";
            this.uOMSettingToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.uOMSettingToolStripMenuItem.Text = "Weight Setting";
            // 
            // uOMToolStripMenuItem
            // 
            this.uOMToolStripMenuItem.Name = "uOMToolStripMenuItem";
            this.uOMToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.uOMToolStripMenuItem.Text = "UoM";
            this.uOMToolStripMenuItem.Click += new System.EventHandler(this.click_Uom);
            // 
            // uOMOfDimensionToolStripMenuItem
            // 
            this.uOMOfDimensionToolStripMenuItem.Name = "uOMOfDimensionToolStripMenuItem";
            this.uOMOfDimensionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.uOMOfDimensionToolStripMenuItem.Text = "Unit of Weight";
            this.uOMOfDimensionToolStripMenuItem.Click += new System.EventHandler(this.click_UnitOfWeight);
            // 
            // packagingToolStripMenuItem
            // 
            this.packagingToolStripMenuItem.Name = "packagingToolStripMenuItem";
            this.packagingToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.packagingToolStripMenuItem.Text = "Packaging";
            this.packagingToolStripMenuItem.Click += new System.EventHandler(this.click_Package);
            // 
            // dimensionSettingToolStripMenuItem
            // 
            this.dimensionSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dimensionToolStripMenuItem,
            this.unitOfDimensionToolStripMenuItem});
            this.dimensionSettingToolStripMenuItem.Name = "dimensionSettingToolStripMenuItem";
            this.dimensionSettingToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.dimensionSettingToolStripMenuItem.Text = "Dimension Setting";
            // 
            // dimensionToolStripMenuItem
            // 
            this.dimensionToolStripMenuItem.Name = "dimensionToolStripMenuItem";
            this.dimensionToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.dimensionToolStripMenuItem.Text = "Dimension";
            this.dimensionToolStripMenuItem.Click += new System.EventHandler(this.click_Dimension);
            // 
            // unitOfDimensionToolStripMenuItem
            // 
            this.unitOfDimensionToolStripMenuItem.Name = "unitOfDimensionToolStripMenuItem";
            this.unitOfDimensionToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.unitOfDimensionToolStripMenuItem.Text = "Unit of Volume";
            this.unitOfDimensionToolStripMenuItem.Click += new System.EventHandler(this.click_UnitOfVolume);
            // 
            // transportSettingToolStripMenuItem
            // 
            this.transportSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierToolStripMenuItem,
            this.truckToolStripMenuItem});
            this.transportSettingToolStripMenuItem.Name = "transportSettingToolStripMenuItem";
            this.transportSettingToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.transportSettingToolStripMenuItem.Text = "Transport Setting";
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.supplierToolStripMenuItem.Text = "Supplier";
            this.supplierToolStripMenuItem.Click += new System.EventHandler(this.click_Suplier);
            // 
            // truckToolStripMenuItem
            // 
            this.truckToolStripMenuItem.Name = "truckToolStripMenuItem";
            this.truckToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.truckToolStripMenuItem.Text = "Truck";
            this.truckToolStripMenuItem.Click += new System.EventHandler(this.click_Truck);
            // 
            // storageToolStripMenuItem
            // 
            this.storageToolStripMenuItem.Name = "storageToolStripMenuItem";
            this.storageToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.storageToolStripMenuItem.Text = "Storage";
            this.storageToolStripMenuItem.Click += new System.EventHandler(this.click_Storage);
            // 
            // departmentToolStripMenuItem
            // 
            this.departmentToolStripMenuItem.Name = "departmentToolStripMenuItem";
            this.departmentToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.departmentToolStripMenuItem.Text = "Department";
            this.departmentToolStripMenuItem.Click += new System.EventHandler(this.click_Department);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.userToolStripMenuItem.Text = "Delivery Place";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.click_DeliveryPlace);
            // 
            // userToolStripMenuItem1
            // 
            this.userToolStripMenuItem1.Name = "userToolStripMenuItem1";
            this.userToolStripMenuItem1.Size = new System.Drawing.Size(206, 26);
            this.userToolStripMenuItem1.Text = "User Management";
            this.userToolStripMenuItem1.Click += new System.EventHandler(this.click_UserManagement);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 721);
            this.Controls.Add(this.mainMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1061, 728);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse IO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem inbondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outbondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inOutActivityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem monitorSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uOMSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uOMOfDimensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packagingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimensionSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitOfDimensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem1;
    }
}


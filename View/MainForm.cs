using System;
using System.Drawing;
using System.Windows.Forms;
using Warehouse_IO.Common;
using Warehouse_IO.View;
using Warehouse_IO.View.DeliveryplaceSource;
using Warehouse_IO.View.Dimension.UnitOfVolumeSource;
using Warehouse_IO.View.Dimensions.DimensionSource;
using Warehouse_IO.View.In_Out_ActivityForm;
using Warehouse_IO.View.InboundSource;
using Warehouse_IO.View.OutboundSource;
using Warehouse_IO.View.ProductSource;
using Warehouse_IO.View.SupplierFormSource;
using Warehouse_IO.View.TruckFormSource;
using Warehouse_IO.View.UOMSource;
using Warehouse_IO.View.Weight.PackagingSource;
using Warehouse_IO.View.Weight.UnitOfWeightSource;

namespace Warehouse_IO
{
    public partial class MainForm : Form
    {

        Log_In_Window loginWindow;
        DepartmentForm dep;
        StorageLocationForm sto;
        SupplierForm sup;
        TruckForm truck;
        UnitOfVolumeForm uOfV;
        UnitOfWeightForm uOfW;
        PackagingForm pack;
        UOMForm uom;
        DimensionsForm dimension;
        ProductForm product;
        InboundForm inbound;
        OutboundForm outbound;
        DeliveryplaceForm deliveryplace;
        InOutActivityForm inoutactivity;

        public MainForm()
        {
            InitializeComponent();
            DisableMainForm();
            loginWindow = new Log_In_Window();

        }
        private void DisableMainForm()
        {
            mainMenuStrip.Items["inbondToolStripMenuItem"].Enabled = false;
            mainMenuStrip.Items["outbondToolStripMenuItem"].Enabled = false;
            mainMenuStrip.Items["inOutActivityToolStripMenuItem"].Enabled = false;
            mainMenuStrip.Items["monitorSettingToolStripMenuItem"].Enabled = false;
            mainMenuStrip.Items["settingToolStripMenuItem"].Enabled = false;
        }
        public void EnableMainFormAdmin()
        {

            mainMenuStrip.Items["inbondToolStripMenuItem"].Enabled = true;
            mainMenuStrip.Items["outbondToolStripMenuItem"].Enabled = true;
            mainMenuStrip.Items["inOutActivityToolStripMenuItem"].Enabled = true;
            mainMenuStrip.Items["monitorSettingToolStripMenuItem"].Enabled = true;
            mainMenuStrip.Items["settingToolStripMenuItem"].Enabled = true;
        }
        private void EventToActiveAdmin(object sender, EventArgs e)
        {
            EnableMainFormAdmin();
        }
        public void EnableMainFormUser()
        {
            mainMenuStrip.Items["inbondToolStripMenuItem"].Enabled = true;
            mainMenuStrip.Items["outbondToolStripMenuItem"].Enabled = true;
            mainMenuStrip.Items["inOutActivityToolStripMenuItem"].Enabled = true;
        }
        private void EventToActiveUser(object sender, EventArgs e)
        {
            EnableMainFormUser();
        }

        private void LoginWindow_LoggedIn(object sender, EventArgs e)
        {
            if (Global.isadmin)
            {
                EnableMainFormAdmin();
                loginWindow.Visible = false;
            }
            else
            {
                EnableMainFormUser();
                loginWindow.Visible = false;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            loginWindow.Enabled = true;
            int x = (this.Width - loginWindow.Width) / 2;
            int y = (this.Height - loginWindow.Height) / 2;
            loginWindow.Location = new Point(x, y);
            loginWindow.LoggedIn += LoginWindow_LoggedIn;
            Controls.Add(loginWindow);
            loginWindow.BringToFront();
        }

        private void click_Department(object sender, EventArgs e)
        {
            dep = new DepartmentForm();
            dep.MdiParent = this;
            dep.Show();
            DisableMainForm();

            dep.returnMain += EventToActiveAdmin;
        }
        private void click_Storage(object sender, EventArgs e)
        {
            sto = new StorageLocationForm();
            sto.MdiParent = this;
            sto.Show();
            DisableMainForm();

            sto.returnMain += EventToActiveAdmin;
        }
        private void click_Suplier(object sender, EventArgs e)
        {
            sup = new SupplierForm();
            sup.MdiParent = this;
            sup.Show();
            DisableMainForm();

            sup.returnMain += EventToActiveAdmin;
        }
        private void click_Truck(object sender, EventArgs e)
        {
            truck = new TruckForm();
            truck.MdiParent = this;
            truck.Show();
            DisableMainForm();

            truck.returnMain += EventToActiveAdmin;
        }
        private void click_UnitOfVolume(object sender, EventArgs e)
        {
            uOfV = new UnitOfVolumeForm();
            uOfV.MdiParent = this;
            uOfV.Show();
            DisableMainForm();

            uOfV.returnMain += EventToActiveAdmin;
        }
        private void click_UnitOfWeight(object sender, EventArgs e)
        {
            uOfW = new UnitOfWeightForm();
            uOfW.MdiParent = this;
            uOfW.Show();
            DisableMainForm();

            uOfW.returnMain += EventToActiveAdmin;
        }
        private void click_Package(object sender, EventArgs e)
        {
            pack = new PackagingForm();
            pack.MdiParent = this;
            pack.Show();
            DisableMainForm();

            pack.returnMain += EventToActiveAdmin;
        }
        private void click_Uom(object sender, EventArgs e)
        {
            uom = new UOMForm();
            uom.MdiParent = this;
            uom.Show();
            DisableMainForm();

            uom.returnMain += EventToActiveAdmin;
        }
        private void click_Dimension(object sender, EventArgs e)
        {
            dimension = new DimensionsForm();
            dimension.MdiParent = this;
            dimension.Show();

            DisableMainForm();
            dimension.returnMain += EventToActiveAdmin;
        }
        private void click_Product(object sender, EventArgs e)
        {
            product = new ProductForm();
            product.MdiParent = this;
            product.Show();

            DisableMainForm();
            product.returnMain += EventToActiveAdmin;
        }
        private void click_DeliveryPlace(object sender, EventArgs e)
        {
            deliveryplace = new DeliveryplaceForm();
            deliveryplace.MdiParent = this;
            deliveryplace.Show();

            DisableMainForm();
            deliveryplace.returnMain += EventToActiveAdmin;
        }

        // User part
        private void click_Inbound(object sender, EventArgs e)
        {
            inbound = new InboundForm();
            inbound.MdiParent = this;
            inbound.Show();

            DisableMainForm();
            inbound.returnMain += EventToActiveAdmin;
        }
        private void click_Outbound(object sender, EventArgs e)
        {
            outbound = new OutboundForm();
            outbound.MdiParent = this;
            outbound.Show();

            DisableMainForm();
            outbound.returnMain += EventToActiveAdmin;
        }

        private void click_InOut(object sender, EventArgs e)
        {
            inoutactivity = new InOutActivityForm();
            inoutactivity.MdiParent = this;
            inoutactivity.Show();

            DisableMainForm();
            inoutactivity.returnMain += EventToActiveAdmin;
        }
    }
}

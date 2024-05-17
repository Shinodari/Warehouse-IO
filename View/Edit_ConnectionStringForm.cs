using System;
using System.Windows.Forms;
using System.Configuration;

namespace Warehouse_IO.View
{
    public partial class Edit_ConnectionStringForm : Form
    {
        //server=127.0.0.1;uid=root;pwd=12345678;database=warehouse-io
        MainForm main;

        public event EventHandler returnMain;

        public Edit_ConnectionStringForm()
        {
            InitializeComponent();
            main = new MainForm();
        }
        private void Edit_ConnectionStringForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void EditConnectionString()
        {
            string ip = ipServerTextbox.Text;
            string id = userDatabaseTextbox.Text;
            string pass = passwordDatabaseTextBox.Text;
            string dbName = databaseNameTextBox.Text;

            string connectionString = $"server={ip};uid={id};pwd={pass};database={dbName}";

            //Settings.Default.CONNECTION_STRING = connectionString;
            //Settings.Default.Save();
            //Settings.Default.Reload();

            MessageBox.Show("Connection string updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            EditConnectionString();
        }
    }
}

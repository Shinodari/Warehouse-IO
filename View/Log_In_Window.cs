using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Warehouse_IO.Authentication;
using Warehouse_IO.Common;

namespace Warehouse_IO
{
    public partial class Log_In_Window : UserControl
    {
        public event EventHandler LoggedIn;
        public Log_In_Window()
        {
            InitializeComponent();          
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            string u = textBox1.Text;
            if (IsValid(u))
            {
                Login log = new Login(textBox1.Text);
                log.Authenticate(textBox2.Text);
                if (log.IsComplete)
                {
                    User userlog = new User(u);
                    Global.isadmin = userlog.IsAdmin;
                    LoggedIn?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show(this,"Invalid");
                }
            }
            else
            {
                MessageBox.Show(this, "Username atleast 6 and no space");
            }
        }
        bool IsValid(string u)
        {
            Regex regex = new Regex(@"^\S.{4,}\S$", RegexOptions.Compiled);
            return regex.IsMatch(u);
        }

        private void Click_Cerate_User(object sender, EventArgs e)
        {
            Create_User create = new Create_User();
            create.Show();
        }
    }
}

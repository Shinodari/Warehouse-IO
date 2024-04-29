using System;
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
            textBox2.KeyPress += LogIn_KeyPress;  
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }
        private void LogIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptLogin();
            }
        }

        private void AttemptLogin()
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
                    MessageBox.Show(this, "Invalid");
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

    }
}

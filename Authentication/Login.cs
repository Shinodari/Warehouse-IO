using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.Authentication
{
    class Login
    {
        User user;
        public User User { get; }

        bool iscomplete;
        public bool IsComplete { get; set; }

        public Login(string username)
        {
            user = new User(username);
        }
        public User GetUser()
        {
            return User;
        }
        public bool GetIsComplete()
        {
            return IsComplete;
        }
        public void Authenticate(string password)
        {
            IsComplete = user.Authenticate(password);
        }
    }
}

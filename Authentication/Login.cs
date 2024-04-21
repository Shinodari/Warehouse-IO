using System;
using System.Collections;
using System.Collections.Generic;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.Authentication
{
    class Login
    {
        User user;
        public User User { get { return user; } }

        bool iscomplete;
        public bool IsComplete { get { return iscomplete; } }

        public Login(string username)
        {
            user = new User(username);
        }

        public void Authenticate(string password)
        {
            iscomplete = user.Authenticate(password);
        }
    }
}

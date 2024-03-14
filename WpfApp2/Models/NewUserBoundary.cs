using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class NewUserBoundary
    {
        private string email;
        private Role role;
        private string username;
        private string avatar;

        public NewUserBoundary()
        {
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
    }
}

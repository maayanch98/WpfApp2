using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class UserId
    {
        private string superapp;
        private string email;

        public UserId()
        {
        }

        public UserId(string superapp, string email)
        {
            this.superapp = superapp;
            this.email = email;
        }

        public string Superapp
        {
            get { return superapp; }
            set { superapp = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public override string ToString()
        {
            return superapp + ":" + email;
        }

        internal string GetEmail()
        {
            throw new NotImplementedException();
        }

        internal string GetSuperapp()
        {
            throw new NotImplementedException();
        }
    }
}

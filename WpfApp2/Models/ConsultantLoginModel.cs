namespace WpfApp2
{
    internal class ConsultantLoginModel
    {
        private string superapp;
        private string email;
        private string userName;
        private string password;
        private string phoneNumber;
        private string Specialization;
        private int Experience;

        public ConsultantLoginModel(string superapp, string email)
        {
            this.superapp = superapp;
            this.email = email;
        }

        public ConsultantLoginModel(string userName, string password, string email, string phoneNumber, string specialization, int experience) : this(userName, password)
        {
            
            this.phoneNumber = phoneNumber;
            Specialization = specialization;
            Experience = experience;
            this.userName = userName;
            this.password = password;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
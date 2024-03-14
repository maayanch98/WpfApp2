namespace WpfApp2
{
    internal class DreamerLoginModel
    {
        private string superapp;
        private string userName;
        private string password;
        private string email;
        private string brithDate;
        private string Gender;
        private string location;

        public DreamerLoginModel(string superapp, string emial)
        {
            this.superapp = superapp;
            this.email = email;
        }

        public DreamerLoginModel(string userName, string password, string email, string brithDate, string gender, string location) : this(userName, password)
        {
            this.email = email;
            this.brithDate = brithDate;
            Gender = gender;
            this.location = location;
        }
    }
}
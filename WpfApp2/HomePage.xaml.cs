using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WpfApp2
{
    public partial class HomePage : Window
    {
        static readonly HttpClient client = new HttpClient();
        String api = "http://localhost:8085";
        private HttpClient httpClient;

        public HomePage()
        {
            InitializeComponent();
            Main();
            // Initialize HttpClient with the base address of your local server
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(api);
            
        }
        static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync
                   ("http://localHost:8085" + "/superapp/users/login/2024a.otiel.malik/a%40a.com");
                response.EnsureSuccessStatusCode();
                Debug.WriteLine(response.EnsureSuccessStatusCode());
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        String s;
        public void UserTypeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            s = ((ComboBoxItem)UserTypeComboBox.SelectedItem).ToString();
            Console.WriteLine(s);
        }


        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Null check for selected item
            if (UserTypeComboBox.SelectedItem != null)
            {
                string userType = ((ComboBoxItem)UserTypeComboBox.SelectedItem).ToString();
                if (userType == "System.Windows.Controls.ComboBoxItem: Dreamer")
                {
                    // Example URL for Dreamer login
                    string dreamerLoginUrl = api + "/dreamerLogin";


                    var loginData = new DreamerLoginModel("username", "password", "emeil", "dd/mm/yyyy", "gender", "location");
                    var response = await httpClient.PostAsync(api, null);

                    // Handle response as needed
                    // Navigate to Dreamer Dashboard or another page
                    DreamerLogin dreamLog = new DreamerLogin();
                    dreamLog.Show();
                    this.Close();
                }
                if (userType == "System.Windows.Controls.ComboBoxItem: Consultant")
                {
                    // Example URL for Consultant login
                    string consultantLoginUrl = api + "/consultantLogin";
                    var loginData = new ConsultantLoginModel("username", "password", "none", "noun", "noun", 0);

                    // You would replace the following line with actual login logic and data
                    var response = await httpClient.PostAsync(consultantLoginUrl, null);

                    // Handle response as needed
                   
                        // Navigate to Consultant Dashboard or another page
                        ConsultantLogin consRgg = new ConsultantLogin();
                        consRgg.Show();
                        this.Close();
                }
                if (userType == "System.Windows.Controls.ComboBoxItem: Admin")
                {
                    MessageBox.Show("ADMIN user must be in the system");

                }

            }
            else
            {
                MessageBox.Show("Select a user type");
            }
        }
        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserTypeComboBox.SelectedItem != null)
            {
                string userType = ((ComboBoxItem)UserTypeComboBox.SelectedItem).ToString();

                if (userType == "System.Windows.Controls.ComboBoxItem: Dreamer")
                {
                    // Example URL for Dreamer login
                    string dreamerRegUrl = api+"/dreamerReg";
                    var DreamerRegisterData = new DreamerRegisterModel("username", "password");
                    // You would replace the following line with actual login logic and data
                    var response = await httpClient.PostAsync(dreamerRegUrl, null);

                    // Handle response as needed
                        // Navigate to Dreamer Dashboard or another page
                        DreamerRegister dreamReg = new DreamerRegister();
                        dreamReg.Show();
                        this.Close();
                }
                if (userType == "System.Windows.Controls.ComboBoxItem: Consultant")
                {
                    // Example URL for Consultant login
                    string consultantRegUrl = api+"/consultantReg";

                    var consRgg = new ConsultantRegisterModel("username", "password");
                    // You would replace the following line with actual login logic and data
                    var response = await httpClient.PostAsync(consultantRegUrl, null);
                    // Handle response as needed
                        // Navigate to Consultant Dashboard or another page
                        ConsultantRegister consReg = new ConsultantRegister();
                        consReg.Show();
                        this.Close(); 
                }
                if (userType == "System.Windows.Controls.ComboBoxItem: Admin")
                {
                    AdminRegister adminReg= new AdminRegister();
                    adminReg.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Select a user type");
            }
        }
    }
}

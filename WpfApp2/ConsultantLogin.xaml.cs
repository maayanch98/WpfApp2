using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using WpfApp1;

namespace WpfApp2
{
    public partial class ConsultantLogin : Window
    {
        private HttpClient httpClient;
        string api = "http://localhost:8085";
        public ConsultantLogin()
        {
            InitializeComponent();

            // Initialize HttpClient with the base address of your server
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(api);
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string superapp = "2024a.otiel.malik";
            string emeil = signupEmail.Text;
            string username = signupUsername.Text;
            string password = signupPassword.Password;
            ObjectBoundary objectBoundary = new ObjectBoundary();
            objectBoundary.Alias=username;
            objectBoundary.Type = "Consultant";
            objectBoundary.ObjectDetails.Add("phoneNumber", phoneNumber.Text);
            objectBoundary.ObjectDetails.Add("Attempt", attemptTextBox.Text);
            objectBoundary.ObjectDetails.Add("specialization", specializationComboBox.Text);



            // You may need to adjust the endpoint according to your server's API
            string loginEndpoint = api+ "/superapp/objects";

            // Prepare the data to be sent to the server
            var loginData = new { superapp = superapp, emeil = emeil };
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
            try
            {
                // Send POST request to the server
                var response = await httpClient.PostAsync(loginEndpoint, content);

                // Handle response
                if (response.IsSuccessStatusCode)
                {
                    // Login successful
                    MessageBox.Show("Login successful");
                    // Navigate to the home page or another page
                    // You can add your navigation logic here
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Login failed. Please check your credentials.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void RegisterHere_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the registration page
            // You can implement this navigation logic according to your application structure
            // For example:
            // RegistrationWindow registrationWindow = new RegistrationWindow();
            // registrationWindow.Show();
            // Close();
        }
    }
}

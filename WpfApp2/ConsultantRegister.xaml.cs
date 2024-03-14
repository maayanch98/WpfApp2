using Microsoft.SqlServer.Server;
using System;
using System.Net.Http;
using System.Windows;
using static System.Net.WebRequestMethods;

namespace WpfApp2
{
    public partial class ConsultantRegister : Window
    {
        private HttpClient httpClient;
        string api = "http://localhost:8085";

        public ConsultantRegister()
        {
            InitializeComponent();

            // Initialize HttpClient with the base address of your local server
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("api");
        }
        


        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            // Get user input
            string superapp = signupUsername.Text;
            string email = signupEmail.Text;

            // Validate user input (optional)
            if (string.IsNullOrWhiteSpace(superapp) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(superapp), "superapp");
                formData.Add(new StringContent(email), "email");

                // Send registration request to the server
                var response = await httpClient.GetAsync(api + "/superapp/users/login/" + superapp + "/" + email);

                //var response = await httpClient.PostAsync("http://localhost:8085/superapp/users/login/2024a.otiel.malik/a%40a.com", null);
                // Check if registration was successful
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Consultant registered successfully.");

                    // pass new screean
                    
                }
                else
                {
                    MessageBox.Show("Failed to register Consultant. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to the login page
            ConsultantLogin loginPage = new ConsultantLogin();
            loginPage.Show();
            Close();
        }
    }
}

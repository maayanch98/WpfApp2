using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WpfApp1;

namespace WpfApp2
{
    public partial class DreamerLogin : Window
    {
        private HttpClient httpClient;

        String Day, Month, Year;
        String api = "http://localhost:8085";

        public DreamerLogin()
        {
            InitializeComponent();

            // Initialize HttpClient with the base address of your local server
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(api);
        }

        private  void Day_ComboBox(object sender, RoutedEventArgs e)
        {
           Day= ((ComboBoxItem)dayComboBox.SelectedItem).Content.ToString();
        }
        private  void Month_ComboBox(object sender, RoutedEventArgs e)
        {
            Month = ((ComboBoxItem)monthComboBox.SelectedItem).Content.ToString();
        }
        private  void Year_ComboBox(object sender, RoutedEventArgs e)
        {
            Year = ((ComboBoxItem)yearComboBox.SelectedItem).Content.ToString();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            ObjectBoundary newDreamer = new ObjectBoundary();
            // Validate input fields and process user registration
            string username = signupUsername.Text;
            string password = signupPassword.Password;
            string email = signupEmail.Text;
            string gender = ((ComboBoxItem)genderComboBox.SelectedItem)?.Content.ToString();
            string location = ((ComboBoxItem)locationComboBox.SelectedItem)?.Content.ToString();
            string birthday = $"{Day}-{Month}-{Year}";

            // Example of validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }



            // Construct JSON object for registration
            string json = $"{{\"username\": \"{username}\", \"password\": \"{password}\", \"email\": \"{email}\", \"gender\": \"{gender}\", \"location\": \"{location}\", \"birthday\": \"{birthday}\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send POST request to the server for registration
            var response = await httpClient.PostAsync(api+ "/superapp/objects", content);

            // Handle response as needed
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Dreamer registered successfully.");
            }
            else
            {
                MessageBox.Show("Failed to register dreamer.");
            }
        }

        private void RegisterHere_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the login page
            DreamerRegister regPage = new DreamerRegister();
            regPage.Show();
            Close();
        }
    }
}

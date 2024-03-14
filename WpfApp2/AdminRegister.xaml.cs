using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for AdminRegister.xaml
    /// </summary>
    public partial class AdminRegister : Window
    {
        private HttpClient httpClient;
        string api = "http://localhost:8085";
        public AdminRegister()
        {
            InitializeComponent();

            // Initialize HttpClient with the base address of your local server
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(api);
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
                if (response.IsSuccessStatusCode)
                {

                    MessageBox.Show("Consultant registered successfully.");
                    AdminPage AdPage = new AdminPage();
                    AdPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to conect admun. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}

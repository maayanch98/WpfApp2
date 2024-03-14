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
    public partial class AdminPage : Window
    {
        private HttpClient httpClient;
        string api = "http://localhost:8085";
        public AdminPage()
        {
            InitializeComponent();

            // Initialize HttpClient with the base address of your local server
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("api");
        }
        private async void Execute_Click(object sender, RoutedEventArgs e)
        {
            string superapp = superappTextBox.Text;
            string email = emailTextBox.Text;
            ComboBoxItem selectedItem = (ComboBoxItem)actionComboBox.SelectedItem;
            string selectedAction = selectedItem.Content.ToString();
            if (string.IsNullOrWhiteSpace(superapp) || string.IsNullOrWhiteSpace(email) || (selectedAction == "System.Windows.Controls.ComboBoxItem: Noune"))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            await PerformAsyncOperation(superapp, email, selectedAction);
        }

        private async Task PerformAsyncOperation(string superapp, string email, string selectedAction)
        {
            // Perform different operations based on the selected action
            switch (selectedAction)
            {
                case "Confirmation":
                    await ConfirmAsync(superapp, email);
                    break;
                case "Deletion":
                    await DeleteAsync(superapp, email);
                    break;
                default:
                    // Handle the "None" case or any other default action
                    break;
            }
        }

        private async Task ConfirmAsync(string superapp, string email)
        {
            // Perform the confirmation operation asynchronously
            await Task.Delay(1000); // Placeholder for actual async operation
            var response = await httpClient.GetAsync(api + "/superapp/admin/users");
            MessageBox.Show($"The user exists in the system executed for Superapp: {superapp}, Email: {email}");
        }

        private async Task DeleteAsync(string superapp, string email)
        {

            var response = await httpClient.GetAsync(api + "/superapp/admin/objects");
            MessageBox.Show($"The user has been deleted from the system executed for Superapp: {superapp}, Email: {email}");
        }
    }
}



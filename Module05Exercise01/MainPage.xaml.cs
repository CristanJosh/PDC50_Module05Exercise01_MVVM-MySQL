using Module05Exercise01.Services;
using MySql.Data.MySqlClient;

namespace Module05Exercise01
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseConnectionService _dbConnectionService;

        public MainPage()
        {
            InitializeComponent();
            _dbConnectionService = new DatabaseConnectionService(); // Ensure your service is initialized
        }

        private async void OpenViewEmployee(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ViewEmployee");
        }

        private async void OnTestConnectionClicked(object sender, EventArgs e)
        {
            var connectionString = _dbConnectionService.GetConnectionString();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    ConnectionStatusLabel.Text = "Connection SUCCESS YEAH!";
                    ConnectionStatusLabel.TextColor = Colors.Green;
                }
            }
            catch (Exception ex)
            {
                ConnectionStatusLabel.Text = $"Connection Failed: {ex.Message}";
                ConnectionStatusLabel.TextColor = Colors.Red;
            }
        }
    }
}

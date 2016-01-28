using Newtonsoft.Json;
using StravaConnect.Clients;
using System.Net.Http;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StravaConnect.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var authenticationClient = new AuthenticationClient();

            // Check authorization code and access token
            if (string.IsNullOrEmpty(App.Settings.AuthorizationCode))
            {
                App.Settings.AuthorizationCode = await authenticationClient.RequestAccessAsync(App.Settings.ClientId);
                App.Settings.AccessToken = await authenticationClient.TokenExchangeAsync(App.Settings.ClientId, App.Settings.ClientSecret, App.Settings.AuthorizationCode);
            }
            else if (string.IsNullOrEmpty(App.Settings.AccessToken)) {
                App.Settings.AccessToken = await authenticationClient.TokenExchangeAsync(App.Settings.ClientId, App.Settings.ClientSecret, App.Settings.AuthorizationCode);
            }

            var stravaClient = new StravaClient(App.Settings.AccessToken);
            var athlete = await stravaClient.Athletes.GetCurrentAthleteAsync();
            var activities = await stravaClient.Activities.GetActivities(per_page: 5);
            this.DataContext = new
            {
                athlete = athlete,
                activity = activities[0]
            };
        }
    }
}

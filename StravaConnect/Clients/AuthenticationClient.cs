using StravaConnect.Authentication;
using StravaConnect.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace StravaConnect.Clients
{
    public class AuthenticationClient
    {
        private HttpJsonClient HttpJsonClient { get; set; }

        public AuthenticationClient()
        {
            HttpJsonClient = new HttpJsonClient();
        }

        /// <summary>
        /// To request access on behalf of a user, redirect the user to Strava’s authorization page,  https://www.strava.com/oauth/authorize (example). 
        /// The page will prompt the user to authorize the app while providing basic information about what is being asked.
        /// </summary>
        /// <param name="client_id">Application’s ID, obtained during registration</param>
        /// <returns>Authorization code</returns>
        public async Task<string> RequestAccessAsync(string client_id)
        {
            string redirect_url = "http://127.0.0.1/token_exchange";
            string stravaURL = string.Format("https://www.strava.com/oauth/authorize?client_id={0}&response_type={1}&redirect_uri={2}&scope={3}&approval_prompt={4}",
                client_id,
                "code",
                redirect_url,
                "write",
                "force"
            );

            var authenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None,
                new Uri(stravaURL),
                new Uri(redirect_url, UriKind.Absolute));

            if (authenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
            {
                string responseData = authenticationResult.ResponseData;
                return responseData.Split('=').Last();
            }

            return string.Empty;
        }

        /// <summary>
        /// If the user accepts the request to share access to their Strava data, Strava will redirect back to redirect_uri with the authorization code. 
        /// The application must now exchange the temporary authorization code for an access token, using its client ID and client secret
        /// </summary>
        /// <param name="client_id">Application’s ID, obtained during registration</param>
        /// <param name="client_secret">Application’s secret, obtained during registration</param>
        /// <param name="authorization_code">Authorization code</param>
        /// <returns>Access token</returns>
        public async Task<string> TokenExchangeAsync(string client_id, string client_secret, string authorization_code)
        {
            var query = string.Format("client_id={0}&client_secret={1}&code={2}",
                client_id,
                client_secret,
                authorization_code);

            var response = await HttpJsonClient.PostAsync<AccessToken>("https://www.strava.com/oauth/token", query);

            return response.Token;
        }
    }
}

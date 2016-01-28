using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Storage;

namespace StravaConnect.UWP.ViewModels
{
    public class SettingsViewModel
    {
        private ApplicationDataContainer localSettings;

        private string _authorizationCode = null;
        public string AuthorizationCode
        {
            get
            {
                if (string.IsNullOrEmpty(_authorizationCode))
                { 
                    if (!localSettings.Values.Keys.Contains("AuthorizationCode"))
                        _authorizationCode = null;
                    else
                        _authorizationCode = localSettings.Values["AuthorizationCode"].ToString();
                }

                return _authorizationCode;
            }
            set
            {
                _authorizationCode = value;
                localSettings.Values["AuthorizationCode"] = _authorizationCode;
                RaisePropertyChanged("AuthorizationCode");
            }
        }

        private string access_token = null;
        public string AccessToken
        {
            get
            {
                if (string.IsNullOrEmpty(access_token))
                {
                    if (!localSettings.Values.Keys.Contains("AccessToken"))
                        access_token = null;
                    else
                        access_token = localSettings.Values["AccessToken"].ToString();
                }

                return access_token;
            }
            set
            {
                access_token = value;
                localSettings.Values["AccessToken"] = access_token;
                RaisePropertyChanged("AccessToken");
            }
        }

        private string client_id = null;
        public string ClientId
        {
            get { return client_id;  }
        }

        private string client_secret = null;
        public string ClientSecret
        {
            get { return client_secret; }
        }


        public SettingsViewModel()
        {
            localSettings = ApplicationData.Current.LocalSettings;

            var config = ResourceLoader.GetForViewIndependentUse("Configuration");
            client_id = config.GetString("client_id"); 
            client_secret = config.GetString("client_secret");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

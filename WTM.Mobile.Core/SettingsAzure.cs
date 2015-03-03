using System;
using System.Net;

namespace WTM.Mobile.Core
{
    public class SettingsAzure : ISettings
    {
        public Uri Host
        {
            get { return new Uri("https://wtmapi.azurewebsites.net:443/api/"); }
        }

        public Uri Proxy
        {
            get { return new Uri("localhost:8888"); }
        }

        public ICredentials ProxyCredentials
        {
            get { return null; }
        }
    }
}
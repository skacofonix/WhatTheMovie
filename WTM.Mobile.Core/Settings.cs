using System;
using System.Net;

namespace WTM.Mobile.Core
{
    public class Settings : ISettings
    {
        public Uri Host { get; set; }

        public Uri Proxy { get; set; }

        public ICredentials ProxyCredentials { get; set; }

        public Settings()
        {
            // Load from ressources
        }
    }
}
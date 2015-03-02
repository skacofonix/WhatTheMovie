using System;
using System.Net;

namespace WTM.Api.Client.Test
{
    public class SettingsProxy : ISettings
    {
        private readonly ISettings settings;

        public SettingsProxy()
        {
            settings = new SettingsAzure();
            //settings = new SettingsLocal();
        }

        public Uri Host
        {
            get { return settings.Host; }
        }

        public Uri Proxy
        {
            get { return settings.Proxy; }
        }

        public ICredentials ProxyCredentials
        {
            get { return settings.ProxyCredentials; }
        }
    }
}

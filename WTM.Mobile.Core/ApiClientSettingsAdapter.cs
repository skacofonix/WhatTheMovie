using System;
using System.Net;

namespace WTM.Mobile.Core
{
    public class ApiClientSettingsAdapter : Api.Client.ISettings
    {
        public Uri Host { get; private set; }
        
        public Uri Proxy { get; private set; }
       
        public ICredentials ProxyCredentials { get; private set; }

        public ApiClientSettingsAdapter(ISettings settings)
        {
            Host = settings.Host;
            Proxy = settings.Proxy;
            ProxyCredentials = settings.ProxyCredentials;
        }
    }
}
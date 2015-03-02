using System;
using System.Net;

namespace WTM.Api.Client.Test
{
    public class SettingsLocal : ISettings
    {
        public Uri Host
        {
            get { return new Uri("http://localhost:56369,/api/"); }
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
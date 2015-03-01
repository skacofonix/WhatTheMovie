using System;
using System.Net;

namespace WTM.Api.Client
{
    public interface ISettings
    {
        Uri Host { get; set; }
        Uri Proxy { get; set; }
        ICredentials ProxyCredentials { get; set; }
    }
}
using System;
using System.Net;

namespace WTM.Api.Client
{
    public interface ISettings
    {
        Uri Host { get; }
        
        Uri Proxy { get; }
        
        ICredentials ProxyCredentials { get; }
    }
}
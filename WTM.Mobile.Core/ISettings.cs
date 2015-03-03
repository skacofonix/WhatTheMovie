using System;
using System.Net;

namespace WTM.Mobile.Core
{
    public interface ISettings
    {
        Uri Host { get; }
        
        Uri Proxy { get;}
        
        ICredentials ProxyCredentials { get; }
    }
}
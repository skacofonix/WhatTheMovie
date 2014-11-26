using System;
using System.IO;
using System.Net;

namespace WTM.Core.Application
{
    public interface IWebClient
    {
        Uri UriBase { get; }
        Stream GetStream(Uri uri);
        WebResponse Post(Uri uri, string data = null);
    }
}
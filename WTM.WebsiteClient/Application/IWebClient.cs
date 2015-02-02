using System;
using System.IO;
using System.Net;

namespace WTM.WebsiteClient.Application
{
    public interface IWebClient
    {
        Uri UriBase { get; }
        Stream GetStream(Uri uri);
        WebResponse Post(Uri uri, string data = null);
        WebResponse Post(Uri source, Uri destination, string data);
        void DownloadFile(Uri uri, string destinationFile);
        void SetCookie(Cookie cookie);
        void RemoveCookie(Cookie cookie);
    }
}
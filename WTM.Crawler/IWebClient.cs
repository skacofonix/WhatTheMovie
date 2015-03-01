using System;
using System.IO;
using System.Net;

namespace WTM.Crawler
{
    public interface IWebClient
    {
        Uri UriBase { get; }
       
        Stream GetStream(Uri uri);

        WebResponse Get(Uri uri);

        WebResponse Post(Uri uri, string data = null);
        
        WebResponse Post(Uri source, Uri destination, string data);
        
        void DownloadFile(Uri uri, string destinationFile);
        
        void SetCookie(Cookie cookie);

        Cookie GetCookie(string name);
        
        void RemoveCookie(Cookie cookie);
    }
}
﻿using System;
using System.IO;
using System.Net;

namespace WTM.WebsiteClient.Test
{
    internal class WebClientFake : IWebClient
    {
        private readonly string htmlContent;

        public Uri UriBase {get { return new Uri("http://whatthemovie.com"); }}

        public Stream GetStream(Uri uri)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(htmlContent);
            ms.Position = 0;

            return ms;
        }

        public WebResponse Get(Uri uri)
        {
            throw new NotImplementedException();
        }

        public WebResponse Post(Uri uri, string data)
        {
            throw new NotImplementedException();
        }

        public WebResponse Post(Uri source, Uri destination, string data)
        {
            throw new NotImplementedException();
        }

        public void DownloadFile(Uri uri, string destinationFile)
        {
            throw new NotImplementedException();
        }

        public void SetCookie(Cookie cookie)
        {
            throw new NotImplementedException();
        }

        public Cookie GetCookie(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveCookie(Cookie cookie)
        {
            throw new NotImplementedException();
        }

        public WebClientFake(string htmlContent)
        {
            this.htmlContent = htmlContent;
        }
    }
}
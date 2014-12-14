﻿using System;
using System.IO;
using System.Net;
using WTM.Core.Application;

namespace WTM.Core.Test.Application
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

        public WebResponse Post(Uri uri, string data)
        {
            throw new NotImplementedException();
        }

        public void DownloadFile(Uri uri, string destinationFile)
        {
            throw new NotImplementedException();
        }

        public WebClientFake(string htmlContent)
        {
            this.htmlContent = htmlContent;
        }
    }
}
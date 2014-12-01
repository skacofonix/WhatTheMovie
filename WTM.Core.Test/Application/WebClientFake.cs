using System;
using System.IO;
using System.Net;
using WTM.Core.Application;

namespace WTM.Core.Test.Application
{
    internal class WebClientFake : WebClientWTM
    {
        private readonly string htmlContent;

        public new Stream GetStream(Uri uri)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(htmlContent);
            ms.Position = 0;

            return ms;
        }

        public new WebResponse Post(Uri uri, string data)
        {
            throw new NotImplementedException();
        }

        public WebClientFake(string htmlContent)
        {
            this.htmlContent = htmlContent;
        }
    }
}
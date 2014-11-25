using System;
using System.IO;
using System.Net;
using WTM.Core.Application;
using WTM.Core.Test.Properties;

namespace WTM.Core.Test.Application
{
    internal class WebClientFake : IWebClient
    {
        public Uri UriBase { get; private set; }

        public Stream GetStream(Uri uri)
        {
            var htmlContent = Resources.shot10;

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
    }
}
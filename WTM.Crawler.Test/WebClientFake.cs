using System;
using System.IO;
using System.Net;

namespace WTM.Crawler.Test
{
    internal class WebClientFake : IWebClient
    {
        private readonly FileInfo htmlFile;

        public WebClientFake(string htmlFilePath)
        {
            htmlFile = new FileInfo(htmlFilePath);
        }

        public Uri UriBase
        {
            get { return new Uri("http://whatthemovie.com"); }
        }

        public Stream GetStream(Uri uri)
        {
            var ms = new MemoryStream();

            using (FileStream fs = htmlFile.OpenRead())
            {
                fs.CopyTo(ms);
            }

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
    }
}
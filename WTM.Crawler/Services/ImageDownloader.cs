using System;
using System.IO;
using System.Net;

namespace WTM.Crawler.Services
{
    public class ImageDownloader : IImageDownloader
    {
        private readonly IWebClient webClient;

        public ImageDownloader(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public byte[] Get(Uri uri, string referer)
        {
            var httpWebRequest = WebRequest.CreateHttp(uri);
            httpWebRequest.Referer = referer;
                
            byte[] rawData = null;

            var response = httpWebRequest.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        rawData = memoryStream.ToArray();
                    }
                }
            }

            return rawData;
        }
    }
}
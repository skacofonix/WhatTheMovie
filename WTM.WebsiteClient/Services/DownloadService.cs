using System;
using WTM.WebsiteClient.Application;

namespace WTM.WebsiteClient.Services
{
    internal class DownloadService
    {
        private readonly IWebClient webClient;

        public DownloadService(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public void Download(Uri uri, string destFile)
        {
            webClient.DownloadFile(uri, destFile);
        }
    }
}
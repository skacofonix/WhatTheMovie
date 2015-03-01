﻿using System;

namespace WTM.Crawler.Services
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
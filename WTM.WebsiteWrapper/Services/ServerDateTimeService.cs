using System;
using System.Net;
using HtmlAgilityPack;
using WTM.Core.Services;

namespace WTM.WebsiteClient.Services
{
    public class ServerDateTimeService : IServerDateTimeService
    {
        private readonly IWebClient webClient;

        public ServerDateTimeService(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public DateTime? GetDateTime()
        {
            var webResponse = webClient.Get(webClient.UriBase) as HttpWebResponse;

            if (webResponse == null)
                return null;

            var dateHeader = webResponse.Headers["Date"];

            DateTime dateTime;
            if (DateTime.TryParse(dateHeader, out dateTime))
                return dateTime;

            return null;
        }
    }
}
using System;
using HtmlAgilityPack;
using WTM.Core.Application;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Services
{
    internal class SettingsService
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;
        private readonly SettingsParser settingsParser;

        public SettingsService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
            settingsParser = new SettingsParser(webClient, htmlParser);
        }

        public Settings Read()
        {
            return settingsParser.Parse();
        }

        public bool Write(Settings settings)
        {
            var source = new Uri(webClient.UriBase, "/user/settings");
            var destination = new Uri(webClient.UriBase, "/user/sitesettings");
            var requestBuilder = new HttpRequestBuilder();
            requestBuilder.AddParameter("_method", "put");
            requestBuilder.AddParameter("user%5Bprefers_arrow_keys_nav%5D", "true");
            requestBuilder.AddParameter("user%5Bprefers_filter_gore%5D", (!settings.ShowGore).ToString().ToLower());
            requestBuilder.AddParameter("user%5Bprefers_filter_nudity%5D", (!settings.ShowNudity).ToString().ToLower());
            requestBuilder.AddParameter("user%5Bnotification_acceptedshot%5D", "email");
            requestBuilder.AddParameter("user%5Bnotification_rejectedshot%5D", "email");
            requestBuilder.AddParameter("user%5Bnotification_deletedshot%5D", "email");
            requestBuilder.AddParameter("user%5Bnotification_friendrequest%5D", "email");
            requestBuilder.AddParameter("user%5Bprefers_newsletter%5D", "true");

            HtmlDocument document = null;
            var webResponse = webClient.Post(source, destination, requestBuilder.ToString());
            using (var stream = webResponse.GetResponseStream())
            {
                document = htmlParser.GetHtmlDocument(stream);
            }

            var readSettings = settingsParser.Parse(document);

            return settings.Equals(readSettings);
        }
    }
}

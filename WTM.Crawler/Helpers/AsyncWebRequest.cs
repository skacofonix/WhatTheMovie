using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using WTM.Crawler.Extensions;

namespace WTM.Crawler.Helpers
{
    internal class AsyncWebRequest
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;

        public AsyncWebRequest(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        private readonly Regex updateElementRegex = new Regex("Element.update\\(\".*\", \"(.*)\"\\);");

        public HtmlDocument DoAsyncGetRequest(Uri uri)
        {
            string rawData;

            using (var stream = webClient.GetStream(uri))
            using (var sr = new StreamReader(stream))
            {
                rawData = sr.ReadToEnd();
            }

            return ParseAsyncHtml(rawData);
        }

        public HtmlDocument DoAsyncPostRequest(Uri uri)
        {
            var rawData = string.Empty;

            using (var webResponse = webClient.Post(uri))
            {
                var stream  = webResponse.GetResponseStream();
                if (stream != null)
                {
                    var streamReader = new StreamReader(stream);
                    rawData = streamReader.ReadToEnd();
                }
            }

            return ParseAsyncHtml(rawData);
        }

        public HtmlDocument ParseAsyncHtml(string rawData)
        {
            var rawDataCleaned = rawData.Replace("\\", string.Empty).CleanString();

            var match = updateElementRegex.Match(rawDataCleaned);

            string bodyHtml = null;
            if (match.Success)
            {
                bodyHtml = match.Groups[1].Value;
            }

            var sb = new StringBuilder();
            sb.Append("<html><body>");
            sb.Append(bodyHtml);
            sb.Append("</html></body>");

            var html = sb.ToString();

            var htmlDocument = htmlParser.GetHtmlDocument(html);

            return htmlDocument;
        }
    }
}

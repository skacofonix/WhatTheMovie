using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal class ShotService : IPageIdentifier
    {
        public string Identifier { get { return "shot"; } }

        private readonly IWebClient webClient;
        private readonly ShotParser shotParser;

        public ShotService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            shotParser = new ShotParser(webClient, htmlParser);
        }

        public Shot Parse(int id)
        {
            return shotParser.Parse(id);
        }

        public Shot ParseRandom()
        {
            return shotParser.Parse("random");
        }

        public GuessTitleResponse GuessTitle(int shotId, string title)
        {
            GuessTitleResponse response = null;

            var titleFormatted = WebUtility.UrlEncode(title.Trim());

            var requestBuilder = new GetRequestBuilder();
            requestBuilder.AddParameter("guess", titleFormatted);
            requestBuilder.AddParameter("commit", "Guess");
            var data = requestBuilder.ToString();

            var post = string.Join("/", Identifier, shotId, "guess");
            var uri = new Uri(webClient.UriBase, post);
            var webResponse = webClient.Post(uri, data);

            string webResponseString = null;
            StreamReader sr;
            using (var stream = webResponse.GetResponseStream())
            using (sr = new StreamReader(stream))
            {
                webResponseString = sr.ReadToEnd();
            }

            if (webResponseString.Contains("guess_right"))
            {
                var regex = new Regex("guess_right\\(\"(.*)\", (\\d*), \"(.*) \\((\\d{4})\\)\"");
                var match = regex.Match(webResponseString);
                if (match.Success)
                {
                    response = new GuessTitleResponse(match.Groups[1].Value, Convert.ToInt32(match.Groups[2].Value), match.Groups[3].Value, Convert.ToInt32(match.Groups[4].Value));
                }
            }

            return response;
        }

        public ShowSolutionResponse ShowSolution(int shotId)
        {
            ShowSolutionResponse response = null;

            var relativeUri = string.Join("/", Identifier, shotId, "showsolution");
            var uri = new Uri(webClient.UriBase, relativeUri);
            var webResponse = webClient.Post(uri);

            string webResponseString;
            using (var stream = webResponse.GetResponseStream())
            using (var sr = new StreamReader(stream))
            {
                webResponseString = sr.ReadToEnd();
            }

            var regexTitle = new Regex("Element.update\\(\"shot_title\", \"<strong>(.*)\\.{3} \\((\\d{4})\\)<\\/strong> <a href=\\\\\"http:\\/\\/whatthemovie.com\\/movie\\/(.*)\\\\\">visit movie page<\\/a>\"\\);");
            var match = regexTitle.Match(webResponseString);
            if (match.Success)
            {
                response = new ShowSolutionResponse(match.Groups[1].Value, Convert.ToInt32(match.Groups[2].Value), match.Groups[3].Value);
            }

            return response;
        }
    }
}

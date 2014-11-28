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

        public bool GuessTitle(int shotId, string title)
        {
            bool isSuccess = false;

            var titleFormatted = WebUtility.UrlEncode(title.Trim());

            var requestBuilder = new GetRequestBuilder();
            requestBuilder.AddParameter("guess", titleFormatted);
            requestBuilder.AddParameter("commit", "Guess");
            var data = requestBuilder.ToString();

            var post = string.Join("/", Identifier, shotId, "guess");
            var uri = new Uri(webClient.UriBase, post);
            var webResponse = webClient.Post(uri, data);

            string response = null;
            StreamReader sr;
            using (var stream = webResponse.GetResponseStream())
                if (stream != null)
                    using (sr = new StreamReader(stream))
                        response = sr.ReadToEnd();

            if (response != null && response.Contains("guess_right"))
            {
                isSuccess = true;

                var regex = new Regex("guess_right\\(\"(.*)\", (\\d*), \"(.*) \\((\\d{4})\\)\"");
                var match = regex.Match(response);
                var guess = match.Groups[1];
                var idMovie = match.Groups[2];
                var originalTitle = match.Groups[3];
                var year = match.Groups[4];
            }

            return isSuccess;
        }

        public bool ShowSolution(int shotId)
        {
            bool isSuccess = false;

            var post = string.Join("/", Identifier, shotId, "showsolution");

            var uri = new Uri(webClient.UriBase, post);
            var webResponse = webClient.Post(uri);

            string response;
            using (var stream = webResponse.GetResponseStream())
            using (var sr = new StreamReader(stream))
            {
                response = sr.ReadToEnd();
            }

            // Try with json deserializer

            var regexTitle = new Regex("Element.update\\(\"shot_title\", \"<strong>(.*)\\.\\.\\. \\((\\d{4})\\)</strong> <a href=\\\"http://whatthemovie.com/movie/(.*)\\\"");
            var match = regexTitle.Match(response);

            if (match.Success)
            {
                isSuccess = false;
                var originalTitle = match.Groups[1];
                var year = match.Groups[2];
                var movieLink = match.Groups[3];
            }

            return isSuccess;
        }
    }
}

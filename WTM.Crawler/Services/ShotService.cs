using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Core.Services;
using WTM.Crawler.Helpers;
using WTM.Crawler.Parsers;
using WTM.Domain;

namespace WTM.Crawler.Services
{
    public class ShotService : IShotService
    {
        private readonly IWebClient webClient;
        private readonly ShotParser shotParser;
        private readonly SearchTagParser shotSearcher;

        public ShotService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            shotParser = new ShotParser(webClient, htmlParser);
            shotSearcher = new SearchTagParser(webClient, htmlParser);
        }

        public Shot GetRandomShot()
        {
            return shotParser.GetRandom();
        }

        public Shot GetById(int id)
        {
            return shotParser.GetById(id);
        }

        public GuessTitleResponse GuessTitle(int id, string title)
        {
            GuessTitleResponse response = null;

            var titleFormatted = WebUtility.UrlEncode(title.Trim());

            var requestBuilder = new HttpRequestBuilder();
            requestBuilder.AddParameter("guess", titleFormatted);
            requestBuilder.AddParameter("commit", "Guess");
            var data = requestBuilder.ToString();

            var post = string.Join("/", "shot", id, "guess");
            var uri = new Uri(webClient.UriBase, post);
            var webResponse = webClient.Post(uri, data);

            string webResponseString = null;
            using (var stream = webResponse.GetResponseStream())
                if (stream != null)
                    using (var sr = new StreamReader(stream))
                        webResponseString = sr.ReadToEnd();

            if (webResponseString != null && webResponseString.Contains("guess_right"))
            {
                var regex = new Regex("guess_right\\(\"(.*)\", (\\d*), \"(.*) \\((\\d{4})\\)\"");
                var match = regex.Match(webResponseString);
                if (match.Success)
                {
                    response = new GuessTitleResponse
                    {
                        MovieId = match.Groups[1].Value,
                        OriginalTitle = match.Groups[3].Value,
                        Year = Convert.ToInt32(match.Groups[4].Value),
                        RightGuess = true
                    };

                    int shotId;
                    if (int.TryParse(match.Groups[2].Value, out shotId))
                        response.ShotId = shotId;
                }
            }

            return response;
        }

        public GuessTitleResponse GetSolution(int id)
        {
            GuessTitleResponse response = null;

            var relativeUri = string.Join("/", "shot", id, "showsolution");
            var uri = new Uri(webClient.UriBase, relativeUri);
            var webResponse = webClient.Post(uri);

            string webResponseString = null;
            using (var stream = webResponse.GetResponseStream())
                if (stream != null)
                    using (var sr = new StreamReader(stream))
                        webResponseString = sr.ReadToEnd();

            if (webResponseString != null)
            {
                var regexTitle = new Regex("Element.update\\(\"shot_title\", \"<strong>(.*)\\.{3} \\((\\d{4})\\)<\\/strong> <a href=\\\\\"http:\\/\\/whatthemovie.com\\/movie\\/(.*)\\\\\">visit movie page<\\/a>\"\\);");
                var match = regexTitle.Match(webResponseString);
                if (match.Success)
                {
                    response = new GuessTitleResponse
                    {
                        OriginalTitle = match.Groups[1].Value,
                        Year = Convert.ToInt32(match.Groups[2].Value),
                        MovieId = match.Groups[3].Value
                    };
                }
            }

            return response;
        }

        public Rate Rate(int id, int score)
        {
            throw new NotImplementedException();
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            var result = shotSearcher.Search(tag, page);

            var shotSummaryCollection = new ShotSummaryCollection
            {
                Shots = result.Items.Cast<ShotSummary>().ToList()
            };

            return shotSummaryCollection;
        }
    }
}
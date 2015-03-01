using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.Interfaces;
using WTM.WebsiteClient.Helpers;
using WTM.WebsiteClient.Parsers;

namespace WTM.WebsiteClient.Services
{
    public class ShotService : IShotService
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;
        private readonly ShotParser shotParser;
        private readonly SearchTagParser shotSearcher;

        public ShotService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
            shotParser = new ShotParser(webClient, htmlParser);
            shotSearcher = new SearchTagParser(webClient, htmlParser);
        }

        public Shot GetRandomShot()
        {
            return shotParser.GetRandom();
        }

        public Shot GetShotById(int id)
        {
            return shotParser.GetById(id);
        }

        public GuessTitleResponse GuessTitle(int shotId, string title)
        {
            GuessTitleResponse response = null;

            var titleFormatted = WebUtility.UrlEncode(title.Trim());

            var requestBuilder = new HttpRequestBuilder();
            requestBuilder.AddParameter("guess", titleFormatted);
            requestBuilder.AddParameter("commit", "Guess");
            var data = requestBuilder.ToString();

            var post = string.Join("/", "shot", shotId, "guess");
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
                    response = new GuessTitleResponse
                    {
                        OriginalTitle = match.Groups[2].Value,
                        MovieId = match.Groups[3].Value,
                        Year = Convert.ToInt32(match.Groups[4].Value),
                        RightGuess = true
                    };
            }

            return response;
        }

        public GuessTitleResponse ShowSolution(int shotId)
        {
            GuessTitleResponse response = null;

            var relativeUri = string.Join("/", "shot", shotId, "showsolution");
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

        public Rate Rate(int score)
        {
            throw new NotImplementedException();
        }

        Movie IShotService.ShowSolution(int shotId)
        {
            Movie movie = null;

            var guessTitleResponse = ShowSolution(shotId);
            if (guessTitleResponse.RightGuess.HasValue && guessTitleResponse.RightGuess.Value)
            {
                var movieParser = new MovieParser(webClient, htmlParser);
                movie = movieParser.GetById(guessTitleResponse.MovieId);
            }

            return movie;
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            throw new NotImplementedException();
            //var result = shotSearcher.Search(tag, page);

            //var shotSummaryCollection = new ShotSummaryCollection
            //{
            //    Shots = result.Items.Cast<ShotSummary>().ToList()
            //};

            //return shotSummaryCollection;
        }
    }
}
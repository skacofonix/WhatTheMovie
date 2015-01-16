using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal abstract class ShotService : IShotService
    {
        protected abstract string PageIdentifier { get; }

        private readonly IWebClient webClient;
        private readonly ShotParser shotParser;

        protected ShotService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            shotParser = new ShotParser(webClient, htmlParser);
        }

        public Shot GetRandomShot()
        {
            return shotParser.ParseRandom();
        }

        public Shot GetFirstShot(Shot currentShot = null)
        {
            var tempShot = currentShot ?? shotParser.ParseRandom();
            if (tempShot != null && tempShot.FirstShotId.HasValue)
                return shotParser.Parse(tempShot.FirstShotId.Value);
            return null;
        }

        public Shot GetPreviousShot(Shot currentShot)
        {
            var tempShot = currentShot;
            if (tempShot != null && tempShot.PreviousShotId.HasValue)
                return shotParser.Parse(tempShot.PreviousShotId.Value);
            return null;
        }

        public Shot GetPreviousUnsolvdShot(Shot currentShot)
        {
            var tempShot = currentShot ?? shotParser.ParseRandom();
            if (tempShot != null && tempShot.PreviousUnsolvedShotId.HasValue)
                return shotParser.Parse(tempShot.PreviousUnsolvedShotId.Value);
            return null;
        }

        public Shot GetNextUnsolvedShot(Shot currentShot)
        {
            var tempShot = currentShot ?? shotParser.ParseRandom();
            if (tempShot != null && tempShot.NextUnsolvedShotId.HasValue)
                return shotParser.Parse(tempShot.NextUnsolvedShotId.Value);
            return null;
        }

        public Shot GetNextShot(Shot currentShot)
        {
            var tempShot = currentShot ?? shotParser.ParseRandom();
            if (tempShot != null && tempShot.NextShotId.HasValue)
                return shotParser.Parse(tempShot.NextShotId.Value);
            return null;
        }

        public Shot GetLastShot(Shot currentShot = null)
        {
            var tempShot = currentShot ?? shotParser.ParseRandom();
            if (tempShot != null && tempShot.LastShotId.HasValue)
                return shotParser.Parse(tempShot.LastShotId.Value);
            return null;
        }

        public Shot GetShotById(int id)
        {
            return shotParser.Parse(id);
        }

        public IEnumerable<Shot> Search(string criteria)
        {
            throw new NotImplementedException();
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
                    response = new GuessTitleResponse(
                        match.Groups[1].Value,
                        Convert.ToInt32(match.Groups[2].Value), 
                        match.Groups[3].Value, 
                        Convert.ToInt32(match.Groups[4].Value));
            }

            return response;
        }

        public ShowSolutionResponse ShowSolution(int shotId)
        {
            ShowSolutionResponse response = null;

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
                    response = new ShowSolutionResponse(
                        match.Groups[1].Value,
                        Convert.ToInt32(match.Groups[2].Value),
                        match.Groups[3].Value);
            }

            return response;
        }

        public bool Rate(int score)
        {
            throw new NotImplementedException();
        }
    }
}
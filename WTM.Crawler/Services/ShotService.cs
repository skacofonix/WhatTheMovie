﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Crawler.Domain;
using WTM.Crawler.Helpers;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class ShotService : IShotService
    {
        private readonly IWebClient webClient;
        private readonly ShotParser shotParser;
        private readonly SearchTagParser shotSearcher;
        private readonly CookieFactory cookieFactory;

        public ShotService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            shotParser = new ShotParser(webClient, htmlParser);
            shotSearcher = new SearchTagParser(webClient, htmlParser);
            cookieFactory = new CookieFactory(webClient);
        }

        public Shot GetRandomShot(string token = null)
        {
            return shotParser.GetRandom(token);
        }

        public Shot GetById(int id, string token = null)
        {
            return shotParser.GetById(id, token);
        }

        public Domain.GuessTitleResponse GuessTitle(int id, string title, string token = null)
        {
            Domain.GuessTitleResponse response = null;

            var titleFormatted = WebUtility.UrlEncode(title.Trim());

            var requestBuilder = new HttpRequestBuilder();
            requestBuilder.AddParameter("guess", titleFormatted);
            requestBuilder.AddParameter("commit", "Guess");
            var data = requestBuilder.ToString();

            var post = string.Join("/", "shot", id, "guess");
            var uri = new Uri(webClient.UriBase, post);

            var cookie = cookieFactory.Create(token);
            webClient.SetCookie(cookie);

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
                    response = new Domain.GuessTitleResponse
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

        public Domain.GuessTitleResponse GetSolution(int id, string token = null)
        {
            Domain.GuessTitleResponse response = null;

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
                    response = new Domain.GuessTitleResponse
                    {
                        OriginalTitle = match.Groups[1].Value,
                        Year = Convert.ToInt32(match.Groups[2].Value),
                        MovieId = match.Groups[3].Value
                    };
                }
            }

            return response;
        }

        public Rate Rate(int id, int score, string token = null)
        {
            throw new NotImplementedException();
        }

        public ShotSummaryCollection Search(string tag, int? page = null, string token = null)
        {
            var result = shotSearcher.Search(tag, page);

            var shotSummaryCollection = new ShotSummaryCollection
            {
                Shots = result.Items.Cast<IShotSummary>().ToList()
            };

            return shotSummaryCollection;
        }
    }
}
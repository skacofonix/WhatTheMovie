﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Crawler.Domain;
using WTM.Crawler.Extensions;
using WTM.Crawler.Helpers;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class ShotService : IShotService
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;
        private readonly ShotParser shotParser;
        private readonly SearchTagParser shotSearcher;
        private readonly CookieFactory cookieFactory;

        public ShotService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
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

        public GuessTitleResponse GuessTitle(int id, string title, string token = null)
        {
            var response = new GuessTitleResponse {ShotId = id};

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
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        webResponseString = sr.ReadToEnd();
                    }
                }
            }

            if (webResponseString != null && webResponseString.Contains("guess_right"))
            {
                var regex = new Regex("guess_right\\(\"(.*)\", (\\d*), \"(.*) \\((\\d{4})\\)\"");
                var match = regex.Match(webResponseString);
                if (match.Success)
                {
                    response.RightGuess = true;
                    response.MovieId = match.Groups[1].Value;
                    response.OriginalTitle = match.Groups[3].Value;
                    response.Year = Convert.ToInt32(match.Groups[4].Value);

                    int shotId;
                    if (int.TryParse(match.Groups[2].Value, out shotId))
                    {
                        response.ShotId = shotId;
                    }
                }
            }

            return response;
        }

        public SolutionTitleResponse GetSolution(int id, string token = null)
        {
            var response = new SolutionTitleResponse {ShotId = id};

            var relativeUri = string.Join("/", "shot", id, "showsolution");
            var uri = new Uri(webClient.UriBase, relativeUri);
            var webResponse = webClient.Post(uri);

            string webResponseString = null;
            using (var stream = webResponse.GetResponseStream())
            { 
                if (stream != null)
                { 
                    using (var sr = new StreamReader(stream))
                    {
                        webResponseString = sr.ReadToEnd();
                    }
                }
            }

            if (webResponseString != null)
            {
                var regexTitle = new Regex("Element.update\\(\"shot_title\", \"<strong>(.*)\\.{3} \\((\\d{4})\\)<\\/strong> <a href=\\\\\"http:\\/\\/whatthemovie.com\\/movie\\/(.*)\\\\\">visit movie page<\\/a>\"\\);");
                var match = regexTitle.Match(webResponseString);
                if (match.Success)
                {
                    response.Available = true;

                    response.MovieId = match.Groups[3].Value;
                    response.OriginalTitle = match.Groups[1].Value;
                    response.Year = Convert.ToInt32(match.Groups[2].Value);
                }
            }

            return response;
        }

        public Rate Rate(int id, int score, string token = null)
        {
            throw new NotImplementedException();
        }
        
        public ShotSearchResult Search(string tag, int? page = null)
        {
            var searchResultCollection = shotSearcher.Search(tag, page);
            return new ShotSearchResult(searchResultCollection);
        }

        public ShotSearchResult GetByMovie(string title)
        {
            var result = new ShotSearchResult(new SearchResultCollection());

            var relativeUri = string.Join("/", "movie", title, "snapshots");
            var uri = new Uri(webClient.UriBase, relativeUri);
            var webResponse = webClient.Post(uri);

            string rawData = null;
            using (var stream = webResponse.GetResponseStream())
            {
                if (stream != null)
                {
                    var document = htmlParser.GetHtmlDocument(stream);

                    var shotNodes = document.DocumentNode.SelectNodes("//ul[@id='carousel_buttons]//a");
                    var links = shotNodes.Select(shotNode => shotNode.GetAttributeValue("href", null)).ToList();

                    var shots = new List<ShotSummary>();

                    for (var index = 0; index < links.Count; index++)
                    {
                        var shotResponse = webClient.Get(new Uri(webClient.UriBase, $"/movie/{title}/carousel_shot?to={index}"));


                    }
                }
            }

            if (rawData != null)
            {
                return result;
            }

            return result;
        }

        public ShotSummary GetShotSummary(string title, int index)
        {
            var webResponse = webClient.Get(new Uri(webClient.UriBase, $"/movie/{title}/carousel_shot?to={index}"));

            string rawData = string.Empty;
            using (var stream = webResponse.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        rawData = sr.ReadToEnd().CleanString();
                    }
                }
            }

            int shotId = 0;
            var regexShotId = new Regex("href=\\\"w*shot/(\\d*)\\\"");
            var matchShotId = regexShotId.Match(rawData);
            if (matchShotId.Success)
            {
                shotId = int.Parse(matchShotId.Groups[1].Value);
            }

            Uri image = null;
            var regexImage = new Regex("img src=\"(\\w*)\"");
            var matchImage = regexImage.Match(rawData);
            if (matchImage.Success)
            {
                image = new Uri(matchImage.Groups[1].Value);
            }

            return new ShotSummary {ImageUri = image, ShotId = shotId};
        }
    }
}
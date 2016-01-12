﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using HtmlAgilityPack;
using WTM.Crawler.Domain;
using WTM.Crawler.Extensions;

namespace WTM.Crawler.Parsers
{
    public class OverviewShotParser : ParserBase<ShotSummaryCollection>
    {
        protected override string Identifier { get { return "overview"; } }

        public OverviewShotParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        const string DateFormat = "yyyy/MM/dd";

        protected override ShotSummaryCollection Parse(string parameter)
        {
            DateTime date;
            if (parameter != null && DateTime.TryParseExact(parameter, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return ParseOverviewShotByDate(date);
            return base.Parse();
        }

        public ShotSummaryCollection ParseOverviewShotByDate(string token = null)
        {
            SetUserToken(token);
            return base.Parse();
        }

        public ShotSummaryCollection ParseByDate(DateTime date, string token = null)
        {
            return ParseOverviewShotByDate(date, token);
        }

        public ShotSummaryCollection ParseNewSubmission(string token = null)
        {
            return ParseCustomOverview("newsubmissions", token);
        }

        public ShotSummaryCollection ParseFeatureFilmsToday(string token = null)
        {
            return ParseCustomOverview("featurefilms", token);
        }

        public ShotSummaryCollection ParseArchiveOneMonthOld(string token = null)
        {
            return ParseCustomOverview("thearchive", token);
        }

        private ShotSummaryCollection ParseCustomOverview(string identifier, string token = null)
        {
            var uri = new Uri(WebClient.UriBase, identifier);
            HtmlDocument document;

            SetUserToken(token);
            using (var stream = WebClient.GetStream(uri))
            {
                document = HtmlParser.GetHtmlDocument(stream);
            }

            var instance = new ShotSummaryCollection();

            ParseHtmlDocument(instance, document);

            return instance;
        }

        private ShotSummaryCollection ParseOverviewShotByDate(DateTime date, string token = null)
        {
            SetUserToken(token);
            var stringDate = date.ToString(DateFormat);
            return base.Parse(stringDate);
        }

        private string GetFirstValue(XPathNavigator navigator, string xPath)
        {
            var singleNode = navigator.SelectSingleNode(xPath);
            return singleNode != null ? singleNode.InnerXml : null;
        }

        protected override void ParseHtmlDocument(ShotSummaryCollection instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null) return;

            var dateString = GetFirstValue(navigator, "//div[@id='hidden_date']");
            if (dateString != null)
            {
                var dateMatch = Regex.Match(dateString.CleanString(), "(\\d{2}) (\\d{2}) (\\d{4})");
                if (dateMatch.Success)
                {
                    var year = int.Parse(dateMatch.Groups[3].Value);
                    var month = int.Parse(dateMatch.Groups[1].Value);
                    var day = int.Parse(dateMatch.Groups[2].Value);

                    var date = new DateTime(year, month, day);
                    instance.Date = date;
                }
            }

            var subTitleNode = navigator.SelectSingleNode("//h2[@class='topbar_title']");
            if (subTitleNode != null)
            {
                var subTitleString = subTitleNode.InnerXml.CleanString();

                switch (subTitleString)
                {
                    case "The Archive":
                        instance.ShotType = ShotType.Archive;
                        break;
                    case "Feature Films":
                        instance.ShotType = ShotType.FeatureFilms;
                        break;
                    case "New Submissions":
                        instance.ShotType = ShotType.NewSubmissions;
                        break;
                    case "Rejected Snapshots":
                        instance.ShotType = ShotType.Rejected;
                        break;
                }
            }

            const string xPathItemRoot = @"//ul[@id='overview_movie_list']/li";
            var nodeIterator = navigator.Select(xPathItemRoot);

            var overviewShotList = new List<IShotSummary>();
            while (nodeIterator.MoveNext())
            {
                var shotSummary = new ShotSummary();

                if (instance.ConnectedUsername != null)
                {
                    var nodeUnsolved = GetFirstValue(nodeIterator.Current, ".//@class");
                    if (!string.IsNullOrEmpty(nodeUnsolved))
                    {
                        switch (nodeUnsolved)
                        {
                            case "unsolved":
                                shotSummary.UserStatus = ShotUserStatus.NeverSolved;
                                break;
                            case "punsolved":
                                shotSummary.UserStatus = ShotUserStatus.Unsolved;
                                break;
                            case "solved":
                                shotSummary.UserStatus = ShotUserStatus.Solved;
                                break;
                        }
                    }
                }

                var imgSrc = GetFirstValue(nodeIterator.Current, ".//div[@class='box']/div/a/img/@src");
                if (!string.IsNullOrEmpty(imgSrc))
                {
                    string uriRaw;
                    if (!imgSrc.StartsWith("http:"))
                        uriRaw = "http:" + imgSrc;
                    else
                        uriRaw = imgSrc;

                    Uri uri;
                    if (Uri.TryCreate(uriRaw, UriKind.Absolute, out uri))
                        shotSummary.ImageUri = uri;
                }

                var nodeShotUrl = GetFirstValue(nodeIterator.Current, ".//div[@class='box']/div/a[1]/@href");
                var regexLastDecimal = new Regex(@"(\d*)$");
                if (!string.IsNullOrEmpty(nodeShotUrl))
                {
                    var match = regexLastDecimal.Match(nodeShotUrl);
                    var shotIdString = match.Groups[1].Value;
                    shotSummary.ShotId = Convert.ToInt32(shotIdString);
                }

                overviewShotList.Add(shotSummary);
            }

            instance.Shots = overviewShotList.ToList();
        }
    }
}
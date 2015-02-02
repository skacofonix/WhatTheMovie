using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using HtmlAgilityPack;
using WTM.WebsiteClient.Domain;
using WTM.WebsiteClient.Helpers;

namespace WTM.WebsiteClient.Application.Parsers
{
    internal class OverviewShotParser : ParserBase<OverviewShotCollection>
    {
        public override string Identifier { get { return "overview"; } }

        public OverviewShotParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        const string DateFormat = "yyyy/MM/dd";

        protected override OverviewShotCollection Parse(string parameter)
        {
            DateTime date;
            if (parameter != null && DateTime.TryParseExact(parameter, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return ParseOverviewShotByDate(date);
            return base.Parse();
        }

        public OverviewShotCollection ParseOverviewShotByDate()
        {
            return base.Parse();
        }

        public OverviewShotCollection ParseByDate(DateTime date)
        {
            return ParseOverviewShotByDate(date);
        }

        public OverviewShotCollection ParseByDate(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            return ParseOverviewShotByDate(date);
        }

        public OverviewShotCollection ParseNewSubmission()
        {
            return ParseCustomOverview("newsubmissions");
        }

        public OverviewShotCollection ParseFeatureFilmsToday()
        {
            return ParseCustomOverview("featurefilms");
        }

        public OverviewShotCollection ParseArchiveOneMonthOld()
        {
            return ParseCustomOverview("thearchive");
        }

        private OverviewShotCollection ParseCustomOverview(string identifier)
        {
            var uri = new Uri(WebClient.UriBase, identifier);
            HtmlDocument document;

            using (var stream = WebClient.GetStream(uri))
            {
                document = HtmlParser.GetHtmlDocument(stream);
            }

            var instance = new OverviewShotCollection();

            ParseHtmlDocument(instance, document);

            return instance;
        }

        private OverviewShotCollection ParseOverviewShotByDate(DateTime date)
        {
            var stringDate = date.ToString(DateFormat);
            return base.Parse(stringDate);
        }

        private string GetFirstValue(XPathNavigator navigator, string xPath)
        {
            var singleNode = navigator.SelectSingleNode(xPath);
            return singleNode != null ? singleNode.InnerXml : null;
        }

        protected override void ParseHtmlDocument(OverviewShotCollection instance, HtmlDocument htmlDocument)
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

            var subTitleNode = navigator.SelectSingleNode("//div[@id='topbar']/h2[@class='topbar_title']");
            if (subTitleNode != null)
            {
                var subTitleString = subTitleNode.InnerXml.CleanString();

                switch (subTitleString)
                {
                    case "The Archive":
                        instance.OverviewShotType = OverviewShotType.Archive;
                        break;
                    case "Feature Films":
                        instance.OverviewShotType = OverviewShotType.FeatureFilms;
                        break;
                    case "New Submissions":
                        instance.OverviewShotType = OverviewShotType.NewSubmissions;
                        break;
                }
            }

            const string xPathItemRoot = @"//ul[@id='overview_movie_list']/li";
            var nodeIterator = navigator.Select(xPathItemRoot);

            var overviewShotList = new List<OverviewShot>();
            while (nodeIterator.MoveNext())
            {
                ShotSolveStatus? shotSolveStatus = null;

                var nodeUnsolved = GetFirstValue(nodeIterator.Current, ".//@class");
                if (!string.IsNullOrEmpty(nodeUnsolved))
                {
                    switch (nodeUnsolved)
                    {
                        case "unsolved":
                            shotSolveStatus = ShotSolveStatus.Unsolved;
                            break;
                        case "punsolved":
                            shotSolveStatus = ShotSolveStatus.PlayerUnsolved;
                            break;
                        case "solved":
                            shotSolveStatus = ShotSolveStatus.Solved;
                            break;
                    }
                }

                var nodeImageUrl = GetFirstValue(nodeIterator.Current, ".//div[@class='box']/div/a/img/@src");

                int? shotId = null;
                var nodeShotUrl = GetFirstValue(nodeIterator.Current, ".//div[@class='box']/div/a[1]/@href");
                var regexLastDecimal = new Regex(@"(\d*)$");
                if (!string.IsNullOrEmpty(nodeShotUrl))
                {
                    var match = regexLastDecimal.Match(nodeShotUrl);
                    var shotIdString = match.Groups[1].Value;
                    shotId = Convert.ToInt32(shotIdString);
                }

                overviewShotList.Add(new OverviewShot(nodeImageUrl, shotId, shotSolveStatus));
            }

            instance.Shots = overviewShotList;
        }
    }
}

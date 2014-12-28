using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
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
                return Parse(date);
            return base.Parse(null);
        }

        public OverviewShotCollection Parse()
        {
            return base.Parse(null);
        }

        public OverviewShotCollection Parse(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            return Parse(date);
        }

        private OverviewShotCollection Parse(DateTime date)
        {
            var stringDate = date.ToString(DateFormat);
            return base.Parse(stringDate);
        }

        private string GetFirstValue(XPathNavigator navigator, string xPath)
        {
            var singleNode = navigator.SelectSingleNode(xPath);
            return singleNode != null ? singleNode.InnerXml : null;
        }

        protected override void Parse(OverviewShotCollection instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null) return;

            var dateString = GetFirstValue(navigator, "//div[@id='hidden_date']");
            if (dateString != null)
            {
                DateTime date;
                if (DateTime.TryParse(dateString, out date))
                    instance.Date = date;
            }

            const string xPathItemRoot = @"//ul[@id='overview_movie_list']/li";
            var nodeIterator = navigator.Select(xPathItemRoot);

            var overviewShotList = new List<OverviewShot>();
            while (nodeIterator.MoveNext())
            {
                var unsolved = false;
                var nodeUnsolved = GetFirstValue(nodeIterator.Current, ".//@class");
                if (!string.IsNullOrEmpty(nodeUnsolved))
                {
                    if (nodeUnsolved == "unsolved")
                        unsolved = true;
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

                overviewShotList.Add(new OverviewShot(nodeImageUrl, shotId, unsolved));
            }

            instance.Shots = overviewShotList;
        }
    }
}

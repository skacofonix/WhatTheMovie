using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Crawler.Domain;

namespace WTM.Crawler.Parsers
{
    internal abstract class SearchBaseParser<T> : ParserBase<SearchResultCollection>
    {
        protected override string Identifier { get { return "search"; } }

        protected abstract string SearchIdentifier { get; }

        protected SearchBaseParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        private readonly Regex rangeDisplayInfoRegex = new Regex("(\\d*)&nbsp;-&nbsp;(\\d*)");

        public SearchResultCollection Search(string criteria, int? page = null)
        {
            var uri = MakeUri(criteria, page);
            return Parse(uri);
        }

        protected override void ParseHtmlDocument(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            // Identify here the use case of result search
            // case 1 : search have zero result
            // case 2 : search have one result
            // case 3 : search have more than 1 result

            var noFoundNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='main_white']/div[@class='col_left nopadding']/p");
            if (noFoundNode != null && noFoundNode.InnerText.Contains($"No {SearchIdentifier} found"))
            {
                // case 1
                instance.RangeItem = new Range(0, 0);
                instance.Count = 0;
                instance.Items = new List<UserSummary>();
                return;
            }

            var singleResultNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='main_white']/ul[@class='tabs_white clearfix page_tabs']");
            if (singleResultNode != null)
            {
                // case 2
                instance.RangeItem = new Range(1, 1);
                instance.Count = 1;
                ParseSingleResultBody(instance, htmlDocument);
                return;
            }

            // case 3
            ParseResultHeader(instance, htmlDocument);
            ParseManyResultBody(instance, htmlDocument);
        }

        protected abstract string TagDisplayInfo { get; }

        private void ParseResultHeader(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            var displayInfoNode = htmlDocument.DocumentNode.SelectSingleNode(string.Format("//div[@class='{0}']/h4", TagDisplayInfo));

            var rangeRawData = displayInfoNode.SelectSingleNode("//b[1]");
            var rangeMatch = rangeDisplayInfoRegex.Match(rangeRawData.InnerHtml);
            if (rangeMatch.Success)
            {
                var min = Convert.ToInt32(rangeMatch.Groups[1].Value);
                var max = Convert.ToInt32(rangeMatch.Groups[2].Value);
                instance.RangeItem = new Range(min, max);
            }

            var totalNode = displayInfoNode.SelectSingleNode("//b[2]");
            if (totalNode == null) return;
            var totalString = totalNode.InnerText;
            int temp;
            if (!string.IsNullOrEmpty(totalString) && int.TryParse(totalString, out temp))
            {
                instance.Count = temp;
            }
        }

        protected abstract void ParseManyResultBody(SearchResultCollection instance, HtmlDocument htmlDocument);

        protected abstract void ParseSingleResultBody(SearchResultCollection instance, HtmlDocument htmlDocument);

        private Uri MakeUri(string criteria, int? page)
        {
            return new Uri(WebClient.UriBase, string.Format("{0}?page={1}&q={2}&t={3}",
                Identifier,
                page.GetValueOrDefault(1),
                WebUtility.UrlEncode(criteria ?? string.Empty),
                SearchIdentifier));
        }
    }
}
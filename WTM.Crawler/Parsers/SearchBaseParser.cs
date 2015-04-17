using HtmlAgilityPack;
using System;
using System.Net;
using System.Text.RegularExpressions;
using WTM.Domain;

namespace WTM.Crawler.Parsers
{
    internal abstract class SearchBaseParser<T> : ParserBase<SearchResultCollection>
    {
        protected override string Identifier { get { return "search"; } }

        protected abstract string SearchIdentifier { get; }

        protected SearchBaseParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected readonly Regex RangeDisplayInfoRegex = new Regex("(\\d*)&nbsp;-&nbsp;(\\d*)");

        public SearchResultCollection Search(string criteria, int? page = null)
        {
            var uri = MakeUri(criteria, page);
            return Parse(uri);
        }

        protected override void ParseHtmlDocument(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            ParseResultHeader(instance, htmlDocument);
            ParseResultBody(instance, htmlDocument);
        }

        protected abstract string TagDisplayInfo { get; }

        private void ParseResultHeader(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            var displayingInfoNode = htmlDocument.DocumentNode.SelectSingleNode(string.Format("//div[@class='{0}']/h4", TagDisplayInfo));

            if (displayingInfoNode == null) return;

            // TODO : case when 1 result was found => redirect to shot/movie/user page
            // TODO : case when there are less than 50 result (1 page)

            var rangeRawData = displayingInfoNode.SelectSingleNode("./b[1]");
            var rangeMatch = RangeDisplayInfoRegex.Match(rangeRawData.InnerHtml);
            if (rangeMatch.Success)
            {
                instance.Range = new Range
                {
                    MinValue = int.Parse(rangeMatch.Groups[1].Value),
                    MaxValue = int.Parse(rangeMatch.Groups[2].Value)
                };
            }

            var totalNode = displayingInfoNode.SelectSingleNode("./b[2]");
            if (totalNode == null) return;
            var totalString = totalNode.InnerText;
            int temp;
            if (!string.IsNullOrEmpty(totalString) && int.TryParse(totalString, out temp))
                instance.Total = temp;
        }

        protected abstract void ParseResultBody(SearchResultCollection instance, HtmlDocument htmlDocument);

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
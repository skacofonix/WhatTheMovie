using HtmlAgilityPack;
using System;
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
            var displayInfoNode = htmlDocument.DocumentNode.SelectSingleNode(string.Format("//div[@class='{0}']/h4", TagDisplayInfo));

            if (displayInfoNode == null)
            {
                var notFoundNode = htmlDocument.DocumentNode.SelectSingleNode(
                        "//div[@id='main_white']/div[@class='col_left nopadding']/p");
                if (notFoundNode != null && notFoundNode.InnerText.Contains("No user found"))
                {
                    instance.RangeItem = new Range(0, 0);
                    instance.Count = 0;
                    return;
                }

                var oneUserFoundNode =
                    htmlDocument.DocumentNode.SelectSingleNode("//div[@id = 'main_white']/div[@class='header_white']/h1");
                if (oneUserFoundNode != null)
                {
                    instance.RangeItem = new Range(1, 1);
                    instance.Count = 1;
                    return;
                }

                // WTF
            }

            var rangeRawData = displayInfoNode.SelectSingleNode("//b[1]");
            var rangeMatch = RangeDisplayInfoRegex.Match(rangeRawData.InnerHtml);
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
using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Collections.Generic;
using WTM.Crawler.Domain;
using WTM.Crawler.Extensions;

namespace WTM.Crawler.Parsers
{
    internal class SearchTagParser : SearchBaseParser<SearchResultCollection>
    {
        protected override string SearchIdentifier { get { return "tag"; } }

        public SearchTagParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected override string TagDisplayInfo { get { return "shot_focus_box"; } }

        protected override void ParseResultBody(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            instance.Items = new List<ShotSummary>();
            var tagNodes = htmlDocument.DocumentNode.SelectNodes("//ul[@class='movie_list clearfix']/li/div/div/a[1]");
            foreach (var tagNode in tagNodes)
            {
                var shotSummary = new ShotSummary();
                instance.Items.Add(shotSummary);

                // Shot ID
                var hrefNode = tagNode.SelectSingleNode("./@href");
                var hrefValue = hrefNode.GetAttributeValue("href", null);
                if (!string.IsNullOrEmpty(hrefValue))
                {
                    int? shotId = hrefValue.ExtractAndParseInt(new Regex("shot/(\\d)*"));
                    if (shotId.HasValue)
                        shotSummary.ShotId = shotId.Value;
                }

                // Image
                var img = tagNode.SelectSingleNode("./img/@src");
                var rawUri = img.GetAttributeValue("src", null);
                if (!string.IsNullOrEmpty(rawUri))
                {
                    Uri uri = null;
                    if (Uri.TryCreate(rawUri, UriKind.Absolute, out uri))
                        shotSummary.ImageUri = uri;
                }
            }
        }
    }
}
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Collections.Generic;
using WTM.Domain;
using WTM.WebsiteClient.Application;

namespace WTM.WebsiteClient.Parsers
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

                var href = tagNode.SelectSingleNode("./@href");
                shotSummary.ImageUrl = href.GetAttributeValue("href", null);

                var img = tagNode.SelectSingleNode("./img/@src");
                shotSummary.ImageUrl = img.GetAttributeValue("src", null);
            }
        }
    }
}
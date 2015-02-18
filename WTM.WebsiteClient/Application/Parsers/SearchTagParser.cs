using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using WTM.Domain;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Application.Parsers
{
    internal class SearchTagParser : SearchBaseParser<SearchResultCollection>
    {
        protected override string SearchIdentifier { get { return "tag"; } }

        public SearchTagParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        private readonly Regex rangeDisplayInfoRegex = new Regex("(\\d*)&nbsp;-&nbsp;(\\d*)");

        protected override void ParseHtmlDocument(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            var displayingInfoNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='shot_focus_box']/h4");

            if (displayingInfoNode != null)
            {
                var rangeRawData = displayingInfoNode.SelectSingleNode("./b[1]");
                var rangeMatch = rangeDisplayInfoRegex.Match(rangeRawData.InnerHtml);
                if (rangeMatch.Success)
                {
                    instance.Range = new Range
                    {
                        MinValue = int.Parse(rangeMatch.Groups[1].Value),
                        MaxValue = int.Parse(rangeMatch.Groups[2].Value)
                    };
                }

                var totalRawData = displayingInfoNode.SelectSingleNode("./b[2]");
                int temp;
                if (int.TryParse(totalRawData.InnerText, out temp))
                    instance.Total = temp;
            }

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
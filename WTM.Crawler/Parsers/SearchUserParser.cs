using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using WTM.Crawler.Domain;

namespace WTM.Crawler.Parsers
{
    internal class SearchUserParser : SearchBaseParser<SearchResultCollection>
    {
        protected override string SearchIdentifier { get { return "user"; } }

        public SearchUserParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected override string TagDisplayInfo { get { return "col_left nopadding"; } }

        protected override void ParseResultBody(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            instance.Items = new List<UserSummary>();

            var displayInfoNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='main_white']/div[@class='col_left nopadding']/h4");
            if (displayInfoNode != null)
            {
                var rangeRawData = displayInfoNode.SelectSingleNode("//b[1]").InnerText;
                var regexRange = new Regex(@"^(\d*)&nbsp;-&nbsp;(\d*)$");
                var match = regexRange.Match(rangeRawData);
                if (match.Success)
                {
                    var min = Convert.ToInt32(match.Groups[1].Value);
                    var max = Convert.ToInt32(match.Groups[2].Value);
                    instance.RangeItem = new Range(min, max);
                }

                var totalRawData = displayInfoNode.SelectSingleNode("//b[2]").InnerText;
                int total;
                if (int.TryParse(totalRawData, out total))
                {
                    instance.Count = total;
                }
            }

            // Footer infos
            //var paginationNodes = htmlDocument.DocumentNode.SelectNodes("//div[@id='main_white']/div[@class='col_left nopadding']/div[@class='black_pagination']/a");
            //if (paginationNodes != null)
            //{
            //    var success = true;

            //    int firstPage;
            //    var firstPageRawData = paginationNodes.First().InnerText;
            //    if (!int.TryParse(firstPageRawData, out firstPage))
            //    {
            //        success ^= false;
            //    }

            //    int lastPage;
            //    var lastPageRawData = paginationNodes.Last().InnerText;
            //    if (!int.TryParse(lastPageRawData, out lastPage))
            //    {
            //        success ^= false;
            //    }

            //    if (success)
            //    {
            //        instance.RangePage = new Range(firstPage, lastPage);
            //    }
            //}

            var tagNodes = htmlDocument.DocumentNode.SelectNodes("//li[@class=' big_user']");
            foreach (var tagNode in tagNodes)
            {
                var userSummary = new UserSummary();
                instance.Items.Add(userSummary);

                var usernameNode = tagNode.SelectSingleNode("./a");
                userSummary.Username = usernameNode.GetAttributeValue("title", null);

                var avatarNode = tagNode.SelectSingleNode("./a/span/img");
                var avatarSrc = avatarNode.GetAttributeValue("src", null);
                try
                {
                    if (avatarSrc != null)
                        userSummary.Avatar = new Uri(avatarSrc);
                }
                catch (Exception)
                {
                    userSummary.Avatar = null;
                }

                userSummary.Rank = tagNode.SelectSingleNode("./a/span/span").InnerText;

                // TODO : Read popup content to find country
            }
        }
    }
}
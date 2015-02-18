using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using WTM.Domain;
using WTM.WebsiteClient.Application;

namespace WTM.WebsiteClient.Parsers
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
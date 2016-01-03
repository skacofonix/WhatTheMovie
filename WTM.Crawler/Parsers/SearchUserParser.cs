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

            var tagNodes = htmlDocument.DocumentNode.SelectNodes("//li[@class=' big_user']");
            if (tagNodes == null || tagNodes.Count == 0) return;

            foreach (var tagNode in tagNodes)
            {
                var userSummary = new UserSummary();
                instance.Items.Add(userSummary);

                var usernameNode = tagNode.SelectSingleNode("./a");
                userSummary.Username = usernameNode.GetAttributeValue("title", null);
                var profilHref = usernameNode.GetAttributeValue("href", null);
                if (profilHref != null)
                {
                    try
                    {
                        userSummary.ProfilUrl = new Uri(profilHref);
                    }
                    catch (Exception ex)
                    {
                        instance.ParseInfos.Add(new ParseInfo("ProfilUrl", ParseLevel.Error, "Error occurred when try to parse User profil URL", ex));
                    }
                }

                var avatarNode = tagNode.SelectSingleNode("./a/span/img");
                var avatarSrc = avatarNode.GetAttributeValue("src", null);
                if (avatarSrc != null)
                {
                    try
                    {
                        userSummary.AvatarUrl = new Uri(avatarSrc);
                    }
                    catch (Exception ex)
                    {
                        instance.ParseInfos.Add(new ParseInfo("AvatarUrl", ParseLevel.Error, "Error occurred when try to parse User avater URL", ex));
                    }
                }

                userSummary.Rank = tagNode.SelectSingleNode("./a/span/span").InnerText;

                // TODO : Read popup content to find country
            }
        }
    }
}
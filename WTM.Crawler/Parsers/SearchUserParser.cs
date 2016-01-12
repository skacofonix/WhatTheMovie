using System;
using System.Collections.Generic;
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

        protected override void ParseSingleResultBody(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            var userSummary = new UserSummary();
            instance.Items = new List<UserSummary> { userSummary };

            var mainNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='main_white']");
            if (mainNode == null) return;

            var autographNode = mainNode.SelectSingleNode("//div[contains(@class,'autograph')]");
            if (autographNode == null) return;

            // Avatar URL
            var avatarNode = autographNode.SelectSingleNode(@"span[@class='wrapper']/img/@src");
            var src = avatarNode?.GetAttributeValue("src", null);
            if (src != null)
            {
                try
                {
                    userSummary.AvatarUrl = new Uri(src);
                }
                catch (Exception ex)
                {
                    instance.ParseInfos.Add(new ParseInfo("AvaratUrl", ParseLevel.Error, "Error occured when try to parse Avatar URL", ex));
                }
            }

            // Rank
            var rankNode = autographNode.SelectSingleNode(@"/span[@class='wrapper']/span[@class='avatar_status']");
            if (rankNode != null)
            {
                userSummary.Rank = rankNode.InnerText;
            }

            // Username
            var usernameNode = autographNode.SelectSingleNode("//strong[@class='nametag']");
            if (usernameNode != null)
            {
                userSummary.ConnectedUsername = usernameNode.InnerText;
            }

            userSummary.ProfilUrl = null;
        }

        protected override void ParseManyResultBody(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            instance.Items = new List<UserSummary>();

            var tagNodes = htmlDocument.DocumentNode.SelectNodes("//li[@class=' big_user']");
            if (tagNodes == null || tagNodes.Count == 0) return;

            foreach (var tagNode in tagNodes)
            {
                var userSummary = new UserSummary();
                instance.Items.Add(userSummary);

                var usernameNode = tagNode.SelectSingleNode("./a");
                userSummary.ConnectedUsername = usernameNode.GetAttributeValue("title", null);
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
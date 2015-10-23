using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using HtmlAgilityPack;
using WTM.Crawler.Domain;
using WTM.Crawler.Extensions;

namespace WTM.Crawler.Parsers
{
    internal class UserParser : ParserBase<User>
    {
        protected override string Identifier { get { return "user"; } }

        public UserParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public User GetByUsername(string username)
        {
            return Parse(username);
        }

        protected override void ParseHtmlDocument(User instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
                return;

            var rootNode = htmlDocument.GetElementbyId("main_white");
            if (rootNode == null)
                return;

            var headerNode = rootNode.SelectSingleNode("div[@class='header_white']/h1");
            if (headerNode != null)
            {
                var nameMatch = Regex.Match(headerNode.InnerHtml.CleanString(), "(.*)<span");
                if (nameMatch.Success)
                    instance.Name = nameMatch.Groups[1].Value.Trim();

                var levelNode = headerNode.SelectSingleNode("./span");
                if (levelNode != null)
                {
                    var match = Regex.Match(levelNode.InnerHtml, "<strong>(.*)</strong>");
                    if (match.Success)
                        instance.Level = match.Groups[1].Value;
                }

                var scoreNode = headerNode.SelectSingleNode("./span/em");
                if (scoreNode != null)
                {
                    var scoreMatch = Regex.Match(scoreNode.InnerHtml, "\\((\\d*) WTM bucks\\)");
                    if (scoreMatch.Success)
                    {
                        double score;
                        if (double.TryParse(scoreMatch.Groups[1].Value, out score))
                            instance.Score = score;
                    }
                }
            }

            var imageNode = rootNode.SelectSingleNode("//div[starts-with(@class, 'autograph')]/span[@class='wrapper']/img");
            if (imageNode != null)
            {
                var value = imageNode.GetAttributeValue("src", null);
                if (value != null)
                {
                    Uri uri;
                    if (Uri.TryCreate(value, UriKind.Absolute, out uri))
                        instance.ImageUri = uri;
                }
            }

            var personalInfosNode = rootNode.SelectSingleNode(".//p[@class='personal_information']");
            if (personalInfosNode != null)
            {
                var personalInfosMatch = Regex.Match(personalInfosNode.InnerHtml.CleanString(), "(\\d*), (male|female|unknow), (.*)");
                if (personalInfosMatch.Success)
                {
                    int age;
                    if (int.TryParse(personalInfosMatch.Groups[1].Value, out age))
                        instance.Age = age;

                    switch (personalInfosMatch.Groups[2].Value)
                    {
                        case "male":
                            instance.Gender = Gender.Male;
                            break;
                        case "female":
                            instance.Gender = Gender.Female;
                            break;
                        case "unknow":
                            instance.Gender = Gender.Unknow;
                            break;
                    }

                    instance.Country = personalInfosMatch.Groups[3].Value;
                }
            }

            var playingSinceNode = rootNode.SelectSingleNode(".//p[@class='playing_since']");
            if (playingSinceNode != null)
            {
                var playingSinceYearMatch = Regex.Match(playingSinceNode.InnerHtml, "has joined WTM over (\\d*) years ago");
                if (playingSinceYearMatch.Success)
                {
                    int playingSinceYear;
                    if (int.TryParse(playingSinceYearMatch.Groups[1].Value, out playingSinceYear))
                        instance.PlayingSinceYear = playingSinceYear;
                }
                else
                {
                    var playingSinceMonthMatch = Regex.Match(playingSinceNode.InnerHtml, "has joined WTM about (\\d*) month ago");
                    if (playingSinceMonthMatch.Success)
                    {
                        int playingSinceMonth;
                        if (int.TryParse(playingSinceMonthMatch.Groups[1].Value, out playingSinceMonth))
                            instance.PlayingSinceMonth = playingSinceMonth;
                    }
                }
            }

            var aboutNode = htmlDocument.GetElementbyId("about_text_teaser");
            if (aboutNode != null)
                instance.About = aboutNode.InnerHtml;

            var statNodes = rootNode.SelectNodes("./div[@class='col_right nopadding']/div[@class='box_blank'][2]/div[@class='box_white']/p/strong");
            if (statNodes.Count >= 4)
            {
                var featureFilmSolvedMatch = Regex.Match(statNodes[0].InnerHtml, "(\\d*) Feature Films");
                if (featureFilmSolvedMatch.Success)
                {
                    int featureFilmsSolved;
                    if (int.TryParse(featureFilmSolvedMatch.Groups[1].Value, out featureFilmsSolved))
                        instance.FeatureFilmsSolved = featureFilmsSolved;
                }

                var snapshotSolvedMatch = Regex.Match(statNodes[1].InnerHtml, "(\\d*) Snapshots");
                if (snapshotSolvedMatch.Success)
                {
                    int snapshotSolved;
                    if (int.TryParse(snapshotSolvedMatch.Groups[1].Value, out snapshotSolved))
                        instance.SnapshotSolved = snapshotSolved;
                }

                var culture = new CultureInfo("en-US");

                decimal receivingRating;
                if (decimal.TryParse(statNodes[2].InnerHtml, NumberStyles.Number, culture.NumberFormat, out receivingRating))
                    instance.ReceivingRating = receivingRating;

                decimal favouritedRating;
                if (decimal.TryParse(statNodes[3].InnerHtml, NumberStyles.Number, culture.NumberFormat, out favouritedRating))
                    instance.FavouritedRating = favouritedRating;
            }

            if (instance.Name != null)
            {
                var baseUri = base.MakeUri(instance.Name);

                GetUploadInfos(baseUri, instance);
                GetFavouritesInfos(baseUri, instance);
                GetFellows(baseUri, instance);
                GetMemorabilia(baseUri, instance);
            }
        }

        private void GetUploadInfos(Uri baseUri, User user)
        {
            var navigator = ParsePageAndReturnNavigator(baseUri, "uploads");
            if (navigator == null)
                return;

            var statValues = new int[7];

            var uploadStatsNodes = navigator.Select("//div[@id='container']/div[@id='main_white']/div[@class='col_right nopadding']/div[@class='box_blank']/div[@class='box_white']/ul[@class='big_linklist']/li/a/span");
            while (uploadStatsNodes.MoveNext())
            {
                int statValue;
                if (int.TryParse(uploadStatsNodes.Current.InnerXml, out statValue) && uploadStatsNodes.CurrentPosition <= 7)
                    statValues[uploadStatsNodes.CurrentPosition - 1] = statValue;
            }

            user.UploadFeatureFilmSnapshots = statValues[0];
            user.UploadSnapshotsOfTheDay = statValues[1];
            user.UploadVaultSnapshots = statValues[2];
            user.UploadRejectedSnapshots = statValues[3];
            user.UploadCharacterSnapshots = statValues[4];
            user.UploadTitleSnapshots = statValues[5];
            user.UploadReplacementSnapshots = statValues[6];
        }

        private void GetFavouritesInfos(Uri baseUri, User user)
        {
            var navigator = ParsePageAndReturnNavigator(baseUri, "favshots");
            if (navigator == null)
                return;

            var statValues = new int[4];

            var favouritesStatsNodes = navigator.Select("//div[@id='container']/div[@id='main_white']/div[@class='col_right nopadding']/div[@class='box_blank']/div[@class='box_white']/ul[@class='big_linklist']/li/a/span");
            while (favouritesStatsNodes.MoveNext())
            {
                int statValue;
                if (int.TryParse(favouritesStatsNodes.Current.InnerXml, out statValue) && favouritesStatsNodes.CurrentPosition <= 4)
                    statValues[favouritesStatsNodes.CurrentPosition - 1] = statValue;
            }

            user.FavouriteSnapshots = statValues[0];
            user.FavouriteMovies = statValues[1];
            user.FavouriteCharacters = statValues[2];
            user.FavouriteSeries = statValues[3];
        }

        private void GetFellows(Uri baseUri, User user)
        {
            var navigator = ParsePageAndReturnNavigator(baseUri, "friends");
            if (navigator == null)
                return;

            var friendsNodes = navigator.Select("//strong[@class='nametag']");
            var friendsList = new List<string>(friendsNodes.Count);
            while (friendsNodes.MoveNext())
            {
                friendsList.Add(friendsNodes.Current.InnerXml);
            }

            user.Friends = friendsList;
        }

        private void GetMemorabilia(Uri baseUri, User user)
        {
            var navigator = ParsePageAndReturnNavigator(baseUri, "memorabilia");
            if (navigator == null)
                return;

            var memorabiliaRoot = navigator.Select("//div[@class='row'][1]/ul[@class='clearfix']/script");

            var tipRegex = new Regex("Tip\\('(.*)', '<strong>(.*)</strong> <em>(.*)</em>(.*)'");

            var memorabiliaList = new List<Memorabilia>();

            while (memorabiliaRoot.MoveNext())
            {
                var match = tipRegex.Match(memorabiliaRoot.Current.TypedValue.ToString());

                if (!match.Success)
                    continue;

                var memorabilia = new Memorabilia();
                memorabilia.Title = match.Groups[2].Value;
                memorabilia.Tag = match.Groups[3].Value;
                memorabilia.Description = match.Groups[4].Value.Replace("<br/>", string.Empty);

                var imgNode = navigator.SelectSingleNode(string.Format("//img[@id='{0}']/@src", match.Groups[1].Value));
                if (imgNode == null) continue;

                try
                {
                    var uri = new Uri(imgNode.InnerXml);
                    memorabilia.Image = uri;
                }
                catch
                {
                    memorabilia.Image = null;
                }
            }

            user.MemorabiliaList = memorabiliaList.ToList();
        }

        private XPathNavigator ParsePageAndReturnNavigator(Uri baseUri, string pageName)
        {
            HtmlDocument htmlDocument;

            var userUploadsUri = new Uri(baseUri + "/" + pageName);
            using (var stream = WebClient.GetStream(userUploadsUri))
            {
                htmlDocument = HtmlParser.GetHtmlDocument(stream);
            }

            if (htmlDocument == null)
                return null;

            return htmlDocument.CreateNavigator();
        }
    }
}
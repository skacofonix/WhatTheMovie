using System;
using System.Globalization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Helpers;

namespace WTM.Core.Application.Parsers
{
    internal class UserParser : ParserBase<User>
    {
        public override string Identifier { get { return "user"; } }

        public UserParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public new User Parse(string id)
        {
            return base.Parse(id);
        }

        protected override void Parse(User instance, HtmlDocument htmlDocument)
        {
            instance.ParseDateTime = DateTime.Now;

            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
                return;

            var rootNode = htmlDocument.GetElementbyId("main_white");
            if (rootNode == null)
                return;

            var headerNode = rootNode.SelectSingleNode("div[@class='header_white']/h1");
            if (headerNode != null)
            {
                var nameMatch = Regex.Match(headerNode.InnerHtml, "(.*)<span");
                if (nameMatch.Success)
                    instance.Name = nameMatch.Groups[1].Value.CleanString();

                var levelNode = headerNode.SelectSingleNode("./span/strong");
                if(levelNode != null)
                    instance.Level = levelNode.InnerHtml;

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

            var personalInfosNode = rootNode.SelectSingleNode(".//p[@class='personal_information']");
            if (personalInfosNode != null)
            {
                var personalInfosMatch = Regex.Match(personalInfosNode.InnerHtml.CleanString(), "(\\d*), (male|female|unknow), (.*)");
                if (personalInfosMatch.Success)
                {
                    int age;
                    if (int.TryParse(personalInfosMatch.Groups[1].Value, out age))
                        instance.Age = age;

                    instance.Gender = personalInfosMatch.Groups[2].Value;

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
                    if(int.TryParse(snapshotSolvedMatch.Groups[1].Value, out snapshotSolved))
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
        }
    }
}

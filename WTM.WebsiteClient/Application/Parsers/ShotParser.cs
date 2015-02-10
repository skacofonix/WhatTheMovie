using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using HtmlAgilityPack;
using WTM.Domain;
using WTM.WebsiteClient.Helpers;

namespace WTM.WebsiteClient.Application.Parsers
{
    public class ShotParser : ParserBase<Shot>
    {
        public override string Identifier { get { return "shot"; } }

        private readonly Regex regexShotId = new Regex(@"/shot/(\d*)");

        public ShotParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public Shot ParseRandom()
        {
            return Parse("random");
        }

        public Shot Parse(int id)
        {
            return Parse(id.ToString(CultureInfo.InvariantCulture));
        }

        protected override void ParseHtmlDocument(Shot instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null) return;

            // Navigation
            instance.Navigation = new Navigation();
            instance.Navigation.FirstId = GetFirstShotId(htmlDocument);
            instance.Navigation.PreviousId = GetPreviousShotId(htmlDocument);
            instance.Navigation.PreviousUnsolvedId = GetPreviousUnsolvedShotId(htmlDocument);
            instance.ShotId = GetShotId(htmlDocument).GetValueOrDefault();
            instance.Navigation.NextUnsolvedId = GetNextUnsolvedShotId(htmlDocument);
            instance.Navigation.NextId = GetNextShotId(htmlDocument);
            instance.Navigation.LastId = GetLastShotId(htmlDocument);

            // Shot infos
            instance.Poster = GetPostedBy(htmlDocument);
            instance.Updater = GetUpdater(navigator);
            instance.FirstSolver = GetFirstSolver(navigator);
            instance.NbSolver = GetNumberOfSolver(navigator);
            instance.PublidationDate = GetPostedDate(htmlDocument);
            instance.SolutionDate = GetSolutionDate(navigator);

            // Solution station
            instance.ImageUri = GetImageUrl(htmlDocument);
            instance.UserStatus = GetUserStatus(htmlDocument, instance.NbSolver);
            instance.Rate = GetRate(navigator);
            instance.Languages = GetLanguages(navigator);
            instance.Tags = GetTags(navigator);
            instance.IsGore = GetIsGore(instance.Tags);
            instance.IsNudity = GetIsNudity(instance.Tags);
            instance.IsFavourited = GetIsFavourited(navigator);
            instance.IsBookmarked = GetIsBookmarked(navigator);
            instance.IsSolutionAvailable = GetIsSolutionAvailable(htmlDocument);
            instance.IsVoteDeletation = GetIsVoteDeletation(navigator);
            instance.NumberOfFavourited = GetNumberOfFavourited(htmlDocument);

            // Async call
            //instance.Difficulty = GetDifficulty(htmlDocument);

            var uriShout = new Uri(WebClient.UriBase, "/shout/shot/" + instance.ShotId);
            string shoutString = null;

            using (var stream = WebClient.GetStream(uriShout))
            using (var sr = new StreamReader(stream))
            {
                shoutString = sr.ReadToEnd();
            }

            var shoutStringClean = shoutString.CleanString();

            var regexShout = new Regex("Element.update\\(\"shoutbox\", \"(.*)\"\\);");

            string shoutBodyHtml = null;
            var match = regexShout.Match(shoutStringClean);
            if (match.Success)
            {
                shoutBodyHtml = match.Groups[1].Value;
            }

            var sb = new StringBuilder();
            sb.Append("<html><body>");
            sb.Append(shoutBodyHtml);
            sb.Append("</html></body>");

            var shoutHtml = sb.ToString();

            var shoutDocument = HtmlParser.GetHtmlDocument(shoutHtml);

            var shoutNavigator = shoutDocument.CreateNavigator();
            if (shoutNavigator == null)
                return;

            var shoutRootNode = shoutNavigator.Select("//ul[@id='shoutlist']/li");
            while (shoutRootNode.MoveNext())
            {
                shoutRootNode.Current.SelectSingleNode(".//div/div/strong/a/@title");
            }
        }

        #region Navigation
        
        private int? GetFirstShotId(HtmlDocument document)
        {
            var firstShotIdLink = document.GetElementbyId("first_shot_link")
                                          .GetAttributeValue("href", string.Empty);
            return firstShotIdLink.ExtractAndParseInt(regexShotId);
        }

        private int? GetPreviousShotId(HtmlDocument document)
        {
            var previousShotIdLink = document.GetElementbyId("prev_shot_link")
                                             .GetAttributeValue("href", string.Empty);
            return previousShotIdLink.ExtractAndParseInt(regexShotId);
        }

        private int? GetPreviousUnsolvedShotId(HtmlDocument document)
        {
            var previousUnsolvedShotIdNode = document.GetElementbyId("prev_unsolved_shot_link");
            if (previousUnsolvedShotIdNode == null) return null;
            return previousUnsolvedShotIdNode
                        .GetAttributeValue("href", string.Empty)
                        .ExtractAndParseInt(regexShotId);
        }

        private int? GetShotId(IXPathNavigable htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
                return null;

            var nodeShotId = navigator.SelectSingleNode("//li[@class='number']");

            if (nodeShotId == null)
                return null;

            return nodeShotId.ValueAsInt;
        }

        private int? GetNextUnsolvedShotId(HtmlDocument document)
        {
            var nextUnsolvedShotIdLink = document.GetElementbyId("next_unsolved_shot_link")
                                                 .GetAttributeValue("href", string.Empty);
            return nextUnsolvedShotIdLink.ExtractAndParseInt(regexShotId);
        }

        private int? GetNextShotId(HtmlDocument document)
        {
            var nextShotId = document.GetElementbyId("next_shot_link")
                                     .GetAttributeValue("href", string.Empty);
            return nextShotId.ExtractAndParseInt(regexShotId);
        }

        private int? GetLastShotId(HtmlDocument document)
        {
            var lastShotIdLink = document.GetElementbyId("last_shot_link")
                                         .GetAttributeValue("href", string.Empty);
            return lastShotIdLink.ExtractAndParseInt(regexShotId);
        }

        #endregion

        #region Shot infos

        private string GetPostedBy(HtmlDocument document)
        {
            return document.GetElementbyId("postername")
                                    .Descendants("a")
                                    .FirstOrDefault()
                                    .InnerText;
        }

        private string GetUpdater(XPathNavigator navigator)
        {
            var nodeUpdater = navigator.SelectSingleNode("//div[@id='main_shot']/ul[@class='nav_shotinfo2']/li/a");
            if (nodeUpdater == null) return null;
            return nodeUpdater.InnerXml;
        }

        private string GetFirstSolver(XPathNavigator navigator)
        {
            var nodeFirstSolver = navigator.SelectSingleNode("//div[@id='main_shot']/ul[@class='nav_shotinfo']/li[3]/a[@class='nametaglink']");
            if (nodeFirstSolver == null)
                return null;
            return nodeFirstSolver.InnerXml;
        }

        private int? GetNumberOfSolver(XPathNavigator navigator)
        {
            var solvedNode = navigator.SelectSingleNode(@"//li[@class='solved']");
            if (solvedNode == null) return null;

            var solvedMatch = Regex.Match(solvedNode.InnerXml, @"status: solved \((\d*)\)");
            if (!solvedMatch.Success)
                return null;

            int nbSolver;
            if (int.TryParse(solvedMatch.Groups[1].Value, out nbSolver))
                return nbSolver;

            return null;
        }

        private DateTime? GetPostedDate(HtmlDocument document)
        {
            DateTime date;
            var sectionDate = document.GetElementbyId("hidden_date").InnerText;
            DateTime.TryParse(sectionDate, out date);
            return date;
        }

        private DateTime? GetSolutionDate(XPathNavigator navigator)
        {
            return null;
        }

        #endregion

        #region Solution station

        private string GetImageUrl(HtmlDocument document)
        {
            var imageUrlSection = document.DocumentNode.Descendants("script")
                                                       .Where(s => s.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                       .Select(s => s.InnerText)
                                                       .FirstOrDefault(w => w.Contains("var imageSrc"));
            return imageUrlSection.ExtractValue(new Regex("var imageSrc = '([a-z0-9/.]*)';", RegexOptions.IgnoreCase));
        }

        private ShotUserStatus? GetUserStatus(HtmlDocument document, int? nbOfSolver)
        {
            if (nbOfSolver.GetValueOrDefault(0) > 0)
                return ShotUserStatus.NeverSolved;

            var nodeGuess = document.GetElementbyId("guess");
            if (nodeGuess == null) return null;

            var classGuess = nodeGuess.Attributes.FirstOrDefault(w => w.Name == "class");
            if (classGuess == null)
                return ShotUserStatus.Unsolved;

            if (classGuess.Value.Contains("right"))
                return ShotUserStatus.Solved;
            if (classGuess.Value.Contains("wrong"))
                return ShotUserStatus.Unsolved;

            return ShotUserStatus.Unsolved;
        }

        private Rate GetRate(XPathNavigator navigator)
        {
            var node = navigator.SelectSingleNode("//div[@id='main_shot']/script[4]");
            if (node == null) return null;
            
            var rateRegex = new Regex(@"Overall rating: &lt;strong&gt;(\d.?\d{2})&lt;/strong&gt; \((\d*) votes\)");

            var match = rateRegex.Match(node.InnerXml);
            if (!match.Success) return null;

            var culture = new CultureInfo("en-US");

            var rate = new Rate();
            decimal rateScore;
            if (decimal.TryParse(match.Groups[1].Value, NumberStyles.Number, culture.NumberFormat, out rateScore))
                rate.Score = rateScore;

            int nbRaters;
            if (int.TryParse(match.Groups[2].Value, out nbRaters))
                rate.NbRaters = nbRaters;

            return rate;
        }

        private static List<string> GetLanguages(XPathNavigator navigator)
        {
            var languageRegex = new Regex(@"images/flags/([a-z]*).png");
            var nodes = navigator.Select("//div[@id='solve_station']/div[@class='col_center clearfix']/ul[@class='language_flags']/li/img/@src");
            var languageList = new List<string>(nodes.Count);
            while (nodes.MoveNext())
            {
                var match = languageRegex.Match(nodes.Current.InnerXml);
                if (!match.Success) continue;

                languageList.Add(match.Groups[1].Value);
            }
            return languageList;
        }

        private static List<string> GetTags(XPathNavigator navigator)
        {
            var nodes = navigator.Select("//ul[@id='shot_tag_list']/li/a");
            var tagList = new List<string>(nodes.Count);
            while (nodes.MoveNext())
            {
                tagList.Add(nodes.Current.InnerXml);
            }
            return tagList;
        }

        private bool GetIsGore(IList<string> tags)
        {
            return tags.Contains("gore");
        }

        private bool GetIsNudity(IList<string> tags)
        {
            return tags.Contains("nudity");
        }

        private bool? GetIsFavourited(XPathNavigator navigator)
        {
            var favouritedNode = navigator.SelectSingleNode(@"//a[@id='favbutton']/onclick");
            if (favouritedNode == null) return null;

            var favouriteMatch = Regex.Match(favouritedNode.InnerXml, @"((un)?fav)");
            if (!favouriteMatch.Success) return null;

            var isFavourite = !favouriteMatch.Groups[2].Success;

            return isFavourite;
        }

        private bool? GetIsBookmarked(XPathNavigator navigator)
        {
            var favouritedNode = navigator.SelectSingleNode(@"//a[@id='bookbutton']/onclick");
            if (favouritedNode == null) return null;

            var favouriteMatch = Regex.Match(favouritedNode.InnerXml, @"((un)?watch)");
            if (!favouriteMatch.Success) return null;

            var isFavourite = !favouriteMatch.Groups[2].Success;

            return isFavourite;
        }

        private bool? GetIsSolutionAvailable(HtmlDocument document)
        {
            return false;
        }

        private bool? GetIsVoteDeletation(XPathNavigator navigator)
        {
            return false;
        }

        private int GetNumberOfFavourited(HtmlDocument document)
        {
            int numberOfFavourited = 0;

            var numberOfFavouritedSection = document.GetElementbyId("shot_tags")
                                                    .Descendants("script")
                                                    .Where(script => script.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                    .FirstOrDefault(script => script.InnerText.Contains("This snapshot has been favourites"));

            if (numberOfFavouritedSection != null)
            {
                var value = numberOfFavouritedSection.InnerText.ExtractAndParseInt(new Regex(@"This snapshot has been favourited (\d*) time"));
                numberOfFavourited = value.GetValueOrDefault(0);
            }

            return numberOfFavourited;
        }

        #endregion

        private SnapshotDifficulty GetDifficulty(HtmlDocument document)
        {
            // TODO : extract this in specific class

            //var uriShout = new Uri(WebClient.UriBase, "/shout/shot/" + instance.ShotId);
            //string shoutString = null;

            //using (var stream = WebClient.GetStream(uriShout))
            //using (var sr = new StreamReader(stream))
            //{
            //    shoutString = sr.ReadToEnd();
            //}


            var isEasy = document.GetElementbyId("difficulty_easy")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isEasy)
                return SnapshotDifficulty.Easy;

            var isEasyOrMedium = document.GetElementbyId("difficulty_medium")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isEasyOrMedium)
                return SnapshotDifficulty.Easy | SnapshotDifficulty.Medium;

            var isHard = document.GetElementbyId("difficulty_hard")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isHard)
                return SnapshotDifficulty.Hard;

            return SnapshotDifficulty.Easy | SnapshotDifficulty.Medium | SnapshotDifficulty.Hard;
        }
    }
}
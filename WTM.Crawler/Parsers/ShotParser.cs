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
    public class ShotParser : ParserBase<Shot>
    {
        protected override string Identifier { get { return "shot"; } }

        private readonly Regex regexShotId = new Regex(@"/shot/(\d*)");

        public ShotParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public Shot GetRandom(string userToken = null)
        {
            SetUserToken(userToken);
            return Parse("random");
        }

        public Shot GetById(int id, string userToken = null)
        {
            SetUserToken(userToken);
            return Parse(id.ToString(CultureInfo.InvariantCulture));
        }

        protected override void ParseHtmlDocument(Shot instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
            {
                instance.ParseInfos.Add(new ParseInfo(ParseLevel.Error, "Cannot create navigator"));
                return;
            }

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

            // Solution station
            instance.ImageUri = GetImageUrl(htmlDocument);
            instance.UserStatus = GetUserStatus(htmlDocument, instance.NbSolver, instance.ConnectedUsername);
            instance.Rate = GetRate(navigator);
            instance.Languages = GetLanguages(navigator);
            instance.Tags = GetTags(navigator);
            instance.IsGore = GetIsGore(instance.Tags);
            instance.IsNudity = GetIsNudity(instance.Tags);
            instance.NumberOfDayBeforeSolution = GetNumberOfDayBeforeSolution(navigator);
            if (instance.NumberOfDayBeforeSolution.HasValue)
            {
                instance.IsSolutionAvailable = (instance.NumberOfDayBeforeSolution.Value == 0);
            }
            instance.IsFavourited = GetIsFavourited(navigator);
            instance.IsBookmarked = GetIsBookmarked(navigator);
            instance.IsVoteDeletation = GetIsVoteDeletation(navigator);
            instance.NumberOfFavourited = GetNumberOfFavourited(htmlDocument);

            // Async call
            ParseShouts(instance);
        }

        #region Navigation

        private int? GetFirstShotId(HtmlDocument document)
        {
            return ParseNavigationId(document, "first_shot_link");
        }

        private int? GetPreviousShotId(HtmlDocument document)
        {
            return ParseNavigationId(document, "prev_shot_link");
        }

        private int? GetPreviousUnsolvedShotId(HtmlDocument document)
        {
            return ParseNavigationId(document, "prev_unsolved_shot_link");
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
            return ParseNavigationId(document, "next_unsolved_shot_link");
        }

        private int? GetNextShotId(HtmlDocument document)
        {
            return ParseNavigationId(document, "next_shot_link");
        }

        private int? GetLastShotId(HtmlDocument document)
        {
            return ParseNavigationId(document, "last_shot_link");
        }

        private int? ParseNavigationId(HtmlDocument document, string elementId)
        {
            var elementNode = document.GetElementbyId(elementId);
            if (elementNode == null) return null;
            return elementNode
                .GetAttributeValue("href", string.Empty)
                .ExtractAndParseInt(regexShotId);
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

        private int? GetNumberOfDayBeforeSolution(XPathNavigator navigator)
        {
            int? numberOfDayBeforeSolution = null;

            var smallButtonsNode = navigator.Select("//ul[@class='ss_buttons_small']/script");

            while (smallButtonsNode.MoveNext())
            {
                var scriptNode = smallButtonsNode.Current;

                if(!scriptNode.InnerXml.Contains("solutionbutton"))
                    continue;

                var match = Regex.Match(scriptNode.InnerXml, "solution will be available in about (\\d*) day");
                if(!match.Success)
                    continue;

                int numberOfDayBeforeSolutionTemp;
                if (int.TryParse(match.Groups[1].Value, out numberOfDayBeforeSolutionTemp))
                    numberOfDayBeforeSolution = numberOfDayBeforeSolutionTemp;
            }

            return numberOfDayBeforeSolution;
        }

        #endregion

        #region Solution station

        private Uri GetImageUrl(HtmlDocument document)
        {
            var imageUrlSection = document.DocumentNode.Descendants("script")
                                                       .Where(s => s.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                       .Select(s => s.InnerText)
                                                       .FirstOrDefault(w => w.Contains("var imageSrc"));

            var urn = imageUrlSection.ExtractValue(new Regex("var imageSrc = '([a-z0-9/.:]*\\.jpg)'"));

            var uri = new Uri(WebClient.UriBase, urn);

            return uri;
        }

        private ShotUserStatus? GetUserStatus(HtmlDocument document, int? nbOfSolver, string username)
        {
            if(username == null)
                return ShotUserStatus.NotConnected;

            if (nbOfSolver.GetValueOrDefault(0) == 0)
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

            if (classGuess.Value.Contains("requested"))
                return ShotUserStatus.Requested;

            return ShotUserStatus.Unsolved;
        }

        private Rate GetRate(XPathNavigator navigator)
        {
            Rate rate = null;

            var rateRegex = new Regex(@"Overall rating: &lt;strong&gt;(\d.?\d{2})&lt;/strong&gt; \((\d*) votes\)");

            var nodes = navigator.Select("//div[@id='main_shot']/script");

            while (nodes.MoveNext())
            {
                var node = nodes.Current;

                var match = rateRegex.Match(node.InnerXml);

                if (!match.Success)
                    continue;

                var culture = new CultureInfo("en-US");

                rate = new Rate();
                decimal rateScore;
                if (decimal.TryParse(match.Groups[1].Value, NumberStyles.Number, culture.NumberFormat, out rateScore))
                    rate.Score = rateScore;

                int nbRaters;
                if (int.TryParse(match.Groups[2].Value, out nbRaters))
                    rate.NbRaters = nbRaters;
            }
          
            return rate;
        }

        private static List<string> GetLanguages(XPathNavigator navigator)
        {
            var languageRegex = new Regex(@"flag-c flag-([a-z]*)");
            var nodes = navigator.Select("//ul[@class='language_flags']/li/img/@class");
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

        private bool? GetIsVoteDeletation(XPathNavigator navigator)
        {
            return null;
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

            // It is not possible to determine easly the shot difficulty
            // This informatin doesn't appear anyway in HTML source.
            // The difficulty is define once when the shot move 'NewSubmissions' section to 'FeatureFilm'.
            // The difficulty level rules :
            //  Hard    : < 30 solvers
            //  Medium  : 30 =< solvers < 200
            //  Easy    : >= 200 solvers

            // One way to determine the difficulty level is using the RandomOptions.
            // We look the current configuration of awesome random button :
            //  If difficulty choice selected has 'easy', the difficulty shot was easy
            //  If difficulty choice selected has 'hard', the difficulty shot was hard
            //  If difficulty choice selected has 'easy + medium', the difficulty shot was easy or medium, it is not possible to determine the exact level.
            //  If difficulty choice selected has 'all' it is not possible to determine the difficulty
            // => Using RandomOptionsService to read this information

            // But this solution is not perfect
            // 1. It is not possible to determine the difficulty level when 'easy + medium' or 'all' was selected.
            // 2. If we navigate on a specific shot by ID the real difficulty of this shot can be different with the RandomOption difficulty configuration.

            throw new NotSupportedException("Using RandomOptionsService to read this information");
        }

        private void ParseShouts(Shot instance)
        {
            var asyncWebRequest = new Helpers.AsyncWebRequest(WebClient, HtmlParser);
            var uriShout = new Uri(WebClient.UriBase, "/shout/shot/" + instance.ShotId);
            var shoutDocument = asyncWebRequest.DoAsyncGetRequest(uriShout);

            var shoutNavigator = shoutDocument.CreateNavigator();
            if (shoutNavigator == null)
                return;

            var shoutRootNode = shoutNavigator.Select("//ul[@id='shoutlist']/li");
            while (shoutRootNode.MoveNext())
            {
                shoutRootNode.Current.SelectSingleNode(".//div/div/strong/a/@title");
            }
        }
    }
}
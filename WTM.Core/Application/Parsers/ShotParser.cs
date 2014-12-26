using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Xml.XPath;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Helpers;

namespace WTM.Core.Application.Parsers
{
    internal class ShotParser : ParserBase<Shot>
    {
        public override string Identifier { get { return "shot"; } }

        private readonly Regex regexCleanHtml = new Regex(@"[\r\t\n ]");
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

        protected override void Parse(Shot instance, HtmlDocument htmlDocument)
        {
            base.Parse(instance, htmlDocument);

            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null) return;

            instance.Languages = GetLanguages(navigator);
            instance.Tags = GetTags(navigator);
            GetRate(instance, navigator);

            var uriShout = new Uri(WebClient.UriBase, "/shout/shot/" + instance.ShotId.GetValueOrDefault());
            string shoutString = null;

            using (var stream = WebClient.GetStream(uriShout))
            using (var sr = new StreamReader(stream))
            {
                shoutString = sr.ReadToEnd();
            }

            var regexClean = new Regex("[\t\n]*");
            var shoutStringClean = regexClean.Replace(shoutString, string.Empty);

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

        private static void GetRate(Shot instance, XPathNavigator navigator)
        {
            var node = navigator.SelectSingleNode("//div[@id='main_shot']/script[4]");
            if (node == null) return;

            var rateRegex = new Regex(@"Overall rating: &lt;strong&gt;(\d.?\d{2})&lt;/strong&gt; \((\d*) votes\)");

            var match = rateRegex.Match(node.InnerXml);
            if (!match.Success) return;

            var culture = new CultureInfo("en-US");

            decimal rate;
            if (decimal.TryParse(match.Groups[1].Value, NumberStyles.Number, culture.NumberFormat, out rate))
                instance.Rate = rate;

            int nbRaters;
            if (int.TryParse(match.Groups[2].Value, out nbRaters))
                instance.NbRaters = nbRaters;
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

        #region Custom implementation

        int? GetFirstShotId(HtmlDocument document)
        {
            var firstShotIdLink = document.GetElementbyId("first_shot_link")
                                          .GetAttributeValue("href", string.Empty);
            return firstShotIdLink.ExtractAndParseInt(regexShotId);
        }

        private int? GetPreviousShotId(HtmlDocument document)
        {
            var previousShotIdLink = document.GetElementbyId("prev_shot")
                                             .GetAttributeValue("href", string.Empty);
            return previousShotIdLink.ExtractAndParseInt(regexShotId);
        }

        private int? GetPreviousUnsolvedShotId(HtmlDocument document)
        {
            var previousUnsolvedShotIdLink = document.GetElementbyId("prev_unsolved_shot")
                                                     .GetAttributeValue("href", string.Empty);
            return previousUnsolvedShotIdLink.ExtractAndParseInt(regexShotId);
        }

        private int? GetCurrentShotId(HtmlDocument document)
        {
            var currentShotIdString = document.GetElementbyId("nav_shots")
                                              .ChildNodes.Where(n => n.Name == "li" && n.Attributes.Any(attr => attr.Name == "class" && attr.Value == "number"))
                                              .FirstOrDefault()
                                              .InnerText;
            var currentShotIdCleaned = regexCleanHtml.Replace(currentShotIdString, string.Empty);
            return int.Parse(currentShotIdCleaned);
        }

        private int? GetNextShotId(HtmlDocument document)
        {
            var nextShotId = document.GetElementbyId("next_shot")
                                     .GetAttributeValue("href", string.Empty);
            return nextShotId.ExtractAndParseInt(regexShotId);
        }

        private int? GetNextUnsolvedShotId(HtmlDocument document)
        {
            var nextUnsolvedShotIdLink = document.GetElementbyId("next_unsolved_shot")
                                                 .GetAttributeValue("href", string.Empty);
            return nextUnsolvedShotIdLink.ExtractAndParseInt(regexShotId);
        }

        private int? GetLastShotId(HtmlDocument document)
        {
            var LastShotIdLink = document.GetElementbyId("last_shot_link")
                                         .GetAttributeValue("href", string.Empty);
            return LastShotIdLink.ExtractAndParseInt(regexShotId).Value;
        }

        private string GetImageUrl(HtmlDocument document)
        {
            var imageUrlSection = document.DocumentNode.Descendants("script")
                                                       .Where(s => s.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                       .Select(s => s.InnerText)
                                                       .FirstOrDefault(w => w.Contains("var imageSrc"));
            return imageUrlSection.ExtractValue(new Regex("var imageSrc = '([a-z0-9/.]*)';", RegexOptions.IgnoreCase));
        }

        private DateTime? GetPostedDate(HtmlDocument document)
        {
            DateTime date;
            var sectionDate = document.GetElementbyId("hidden_date").InnerText;
            DateTime.TryParse(sectionDate, out date);
            return date;
        }

        private string GetPostedBy(HtmlDocument document)
        {
            return document.GetElementbyId("postername")
                                    .Descendants("a")
                                    .FirstOrDefault()
                                    .InnerText;
        }

        private int? GetNumberOfSolver(HtmlNode sectionShotInfo)
        {
            var sectionNbSolved = sectionShotInfo.Descendants("li")
                                                 .FirstOrDefault(li => li.Attributes.Any(attr => attr.Name == "class" && attr.Value == "solved"))
                                                 .InnerText;
            return sectionNbSolved.ExtractAndParseInt(new Regex(@"status: solved \((\d*)\)")).GetValueOrDefault(0);
        }

        private string GetFirstSolver(HtmlNode sectionShotInfo)
        {
            return sectionShotInfo.Descendants("li")
                                  .FirstOrDefault(li => li.InnerText.StartsWith("first solved by:"))
                                  .Descendants("a")
                                  .Select(s => s.InnerText)
                                  .FirstOrDefault();
        }

        private bool? GetIsFavourited(HtmlDocument document)
        {
            bool isFavourite = false;

            var isFavouriteOnclickContent = document.GetElementbyId("favbutton")
                                                    .GetAttributeValue("onclick", string.Empty);
            var value = isFavouriteOnclickContent.ExtractValue(new Regex(@"new Ajax.Request\('/shot/\d*/(fav|unfav)'"));
            isFavourite = (value == "unfav");

            return isFavourite;
        }

        private bool? GetIsBookmarked(HtmlDocument document)
        {
            return false;
        }

        private bool? GetIsVoteDeletation(HtmlDocument document)
        {
            return false;
        }

        private bool? GetIsSolutionAvailable(HtmlDocument document)
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

        private string GetDifficulty(HtmlDocument document)
        {
            var isEasy = document.GetElementbyId("difficulty_easy")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isEasy)
                return "easy";

            var isMedium = document.GetElementbyId("difficulty_medium")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isMedium)
                return "medium";

            var isHard = document.GetElementbyId("difficulty_hard")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isHard)
                return "hard";

            return "all";
        }

        #endregion
    }
}
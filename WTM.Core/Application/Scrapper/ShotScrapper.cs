using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using WTM.Core.Application.Attributes;
using WTM.Core.Application.Scrapper.Base;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Scrapper
{
    internal class ShotScrapper : ScrapperT<Shot>
    {
        private readonly Regex regexCleanHtml = new Regex(@"[\r\t\n ]");
        private readonly Regex regexShotId = new Regex(@"/shot/(\d*)");

        protected override string Identifier
        {
            get { return "shot"; }
        }

        private IWebClient webClient;

        public ShotScrapper(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        {
            this.webClient = webClient;
        }

        public bool GuessTitle(string title, int idShot)
        {
            bool guessRight = false;

            var titleFormatted = WebUtility.UrlEncode(title.Trim());

            var requestBuilder = new GetRequestBuilder();
            requestBuilder.AddParameter("guess", titleFormatted);
            requestBuilder.AddParameter("commit", "Guess");
            var data = requestBuilder.ToString();

            string response = null;

            var post = string.Format("/shot/{0}/guess", idShot);
            var uri = new Uri(webClient.UriBase, post);

            var webResponse = webClient.Post(uri, data);
            using (var stream = webResponse.GetResponseStream())
            using(var sr = new StreamReader(stream))
            {
                response = sr.ReadToEnd();
            }

            if (response.Contains("guess_right"))
            {
                guessRight = true;

                var regex = new Regex("guess_right\\(\"(.*)\", (\\d*), \"(.*) \\((\\d{4})\\)\"");
                var match = regex.Match(response);
                var guess = match.Groups[1];
                var idMovie = match.Groups[2];
                var originalTitle = match.Groups[3];
                var year = match.Groups[4];
            }

            return guessRight;
        }

        #region Custom implementation
        
        int? GetFirstShotId()
        {
            var firstShotIdLink = Document.GetElementbyId("first_shot_link")
                                          .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(firstShotIdLink, regexShotId);
        }

        private int? GetPreviousShotId()
        {
            var previousShotIdLink = Document.GetElementbyId("prev_shot")
                                             .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(previousShotIdLink, regexShotId);
        }

        private int? GetPreviousUnsolvedShotId()
        {
            var previousUnsolvedShotIdLink = Document.GetElementbyId("prev_unsolved_shot")
                                                     .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(previousUnsolvedShotIdLink, regexShotId);
        }

        private int? GetCurrentShotId()
        {
            var currentShotIdString = Document.GetElementbyId("nav_shots")
                                              .ChildNodes.Where(n => n.Name == "li" && n.Attributes.Any(attr => attr.Name == "class" && attr.Value == "number"))
                                              .FirstOrDefault()
                                              .InnerText;
            var currentShotIdCleaned = regexCleanHtml.Replace(currentShotIdString, string.Empty);
            return int.Parse(currentShotIdCleaned);
        }

        private int? GetNextShotId()
        {
            var nextShotId = Document.GetElementbyId("next_shot")
                                     .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(nextShotId, regexShotId);
        }

        private int? GetNextUnsolvedShotId()
        {
            var nextUnsolvedShotIdLink = Document.GetElementbyId("next_unsolved_shot")
                                                 .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(nextUnsolvedShotIdLink, regexShotId);
        }

        private int? GetLastShotId()
        {
            var LastShotIdLink = Document.GetElementbyId("last_shot_link")
                                         .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(LastShotIdLink, regexShotId).Value;
        }

        private string GetImageUrl(Shot shot)
        {
            var imageUrlSection = Document.DocumentNode.Descendants("script")
                                                       .Where(s => s.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                       .Select(s => s.InnerText)
                                                       .FirstOrDefault(w => w.Contains("var imageSrc"));
            return ExtractValue(imageUrlSection, new Regex("var imageSrc = '([a-z0-9/.]*)';", RegexOptions.IgnoreCase));
        }

        private DateTime? GetPostedDate(Shot shot)
        {
            DateTime date;
            var sectionDate = Document.GetElementbyId("hidden_date").InnerText;
            DateTime.TryParse(sectionDate, out date);
            return date;
        }

        private string GetPostedBy()
        {
            return Document.GetElementbyId("postername")
                                    .Descendants("a")
                                    .FirstOrDefault()
                                    .InnerText;
        }

        private int? GetNumberOfSolver(HtmlNode sectionShotInfo)
        {
            var sectionNbSolved = sectionShotInfo.Descendants("li")
                                                 .FirstOrDefault(li => li.Attributes.Any(attr => attr.Name == "class" && attr.Value == "solved"))
                                                 .InnerText;
            return ExtractAndParseInt(sectionNbSolved, new Regex(@"status: solved \((\d*)\)")).GetValueOrDefault(0);
        }

        private string GetFirstSolver(HtmlNode sectionShotInfo)
        {
            return sectionShotInfo.Descendants("li")
                                  .FirstOrDefault(li => li.InnerText.StartsWith("first solved by:"))
                                  .Descendants("a")
                                  .Select(s => s.InnerText)
                                  .FirstOrDefault();
        }

        private bool? GetIsFavourited()
        {
            bool isFavourite = false;

            var isFavouriteOnclickContent = Document.GetElementbyId("favbutton")
                                                    .GetAttributeValue("onclick", string.Empty);
            var value = ExtractValue(isFavouriteOnclickContent, new Regex(@"new Ajax.Request\('/shot/\d*/(fav|unfav)'"));
            isFavourite = (value == "unfav");

            return isFavourite;
        }

        private bool? GetIsBookmarked()
        {
            return false;
        }

        private bool? GetIsVoteDeletation()
        {
            return false;
        }

        private bool? GetIsSolutionAvailable()
        {
            return false;
        }

        private List<string> GetLanguages(HtmlNode sectionSolution)
        {
            var regexLanguage = new Regex("//static.whatthemovie.com/images/flags/([a-z]{2,3}).png");
            return sectionSolution.Descendants("ul")
                                  .FirstOrDefault(ul => ul.Attributes.Any(attr => attr.Name == "class" && attr.Value == "language_flags"))
                                  .Descendants("img")
                                  .Select(img => img.Attributes.FirstOrDefault(attr => attr.Name == "src").Value)
                                  .Select(s => regexLanguage.Match(s).Groups[1].Value)
                                  .ToList();
        }

        private List<string> GetTags()
        {
            return Document.GetElementbyId("shot_tag_list")
                           .Descendants("a")
                           .Where(a => a.Attributes.Any(attr => attr.Name == "href" && attr.Value.StartsWith("/search?t=tag")))
                           .Select(s => s.InnerText)
                           .ToList();
        }

        private int GetNumberOfFavourited()
        {
            int numberOfFavourited = 0;

            var numberOfFavouritedSection = Document.GetElementbyId("shot_tags")
                                                    .Descendants("script")
                                                    .Where(script => script.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                    .FirstOrDefault(script => script.InnerText.Contains("This snapshot has been favourites"));

            if (numberOfFavouritedSection != null)
            {
                var value = ExtractAndParseInt(numberOfFavouritedSection.InnerText, new Regex(@"This snapshot has been favourited (\d*) time"));
                numberOfFavourited = value.GetValueOrDefault(0);
            }

            return numberOfFavourited;
        }

        private string GetDifficulty()
        {
            var isEasy = Document.GetElementbyId("difficulty_easy")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isEasy)
                return "easy";

            var isMedium = Document.GetElementbyId("difficulty_medium")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isMedium)
                return "medium";

            var isHard = Document.GetElementbyId("difficulty_hard")
                                 .GetAttributeValue("checked", string.Empty)
                                 .Equals("cheked");
            if (isHard)
                return "hard";

            return "all";
        }

        #endregion
    }
}
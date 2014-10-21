using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application
{
    public class ShotScrapper : ScrapperT<IShot>
    {
        private readonly Regex regexCleanHtml = new Regex(@"[\r\t\n ]");
        private readonly Regex regexShotId = new Regex(@"/shot/(\d*)");
        private readonly Regex regexNumber = new Regex(@"([0-9]*)", RegexOptions.IgnorePatternWhitespace);

        public ShotScrapper(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected override string Identifier
        {
            get { return "shot"; }
        }

        protected override IShot Scrappe()
        {
            var shot = new Shot();

            try
            {
                shot.FirstShotId = GetFirstShotId();
                shot.PreviousShotId = GetPreviousShotId();
                shot.PreviousUnsolvedShotId = GetPreviousUnsolvedShotId();
                shot.ShotId = GetCurrentShotId();
                shot.NextShotId = GetNextShotId();
                shot.PreviousUnsolvedShotId = GetNextUnsolvedShotId();
                shot.LastShotId = GetLastShotId();

                shot.ImageUrl = GetImageUrl(shot);
                shot.PostedDate = GetPostedDate(shot);
                //shot.PostedBy = GetPostedBy();

                var sectionShotInfo = document.GetElementbyId("main_shot")
                                              .Descendants("ul")
                                              .FirstOrDefault(ul => ul.Attributes.Any(attr => attr.Name == "class" && attr.Value == "nav_shotinfo"));
                shot.NbSolver = GetNumberOfSolver(sectionShotInfo);
                //shot.FirstSolver = GetFirstSolver(sectionShotInfo);

                var sectionSolution = document.GetElementbyId("solve_station");
                //shot.IsFavourite = GetIsFavourited();
                //shot.IsBookmark = GetIsBookmarked();
                //shot.IsVoteDeletation = GetIsVoteDeletation();
                //shot.IsSolutionAvailible = GetIsSolutionAvailable();

                shot.Languages = GetLanguages(sectionSolution);

                shot.Tags = GetTags();
                //shot.NbFavourited = GetNumberOfFavourited();

            }
            catch (Exception ex)
            {
                throw;
            }

            return shot;
        }

        private int? GetFirstShotId()
        {
            var firstShotIdLink = document.GetElementbyId("first_shot_link")
                                          .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(firstShotIdLink, regexShotId);
        }

        private int? GetPreviousShotId()
        {
            var previousShotIdLink = document.GetElementbyId("prev_shot")
                                             .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(previousShotIdLink, regexShotId);
        }

        private int? GetPreviousUnsolvedShotId()
        {
            var previousUnsolvedShotIdLink = document.GetElementbyId("prev_unsolved_shot")
                                                     .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(previousUnsolvedShotIdLink, regexShotId);
        }

        private int? GetCurrentShotId()
        {
            var currentShotIdString = document.GetElementbyId("nav_shots")
                                              .ChildNodes.Where(n => n.Name == "li" && n.Attributes.Any(attr => attr.Name == "class" && attr.Value == "number"))
                                              .FirstOrDefault()
                                              .InnerText;
            var currentShotIdCleaned = regexCleanHtml.Replace(currentShotIdString, string.Empty);
            return int.Parse(currentShotIdCleaned);
        }

        private int? GetNextShotId()
        {
            var nextShotId = document.GetElementbyId("next_shot")
                                     .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(nextShotId, regexShotId);
        }

        private int? GetNextUnsolvedShotId()
        {
            var nextUnsolvedShotIdLink = document.GetElementbyId("next_unsolved_shot")
                                                 .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(nextUnsolvedShotIdLink, regexShotId);
        }

        private int? GetLastShotId()
        {
            var LastShotIdLink = document.GetElementbyId("last_shot_link")
                                         .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(LastShotIdLink, regexShotId).Value;
        }

        private string GetImageUrl(IShot shot)
        {
            var imageUrlSection = document.DocumentNode.Descendants("script")
                                                       .Where(s => s.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                       .Select(s => s.InnerText)
                                                       .FirstOrDefault(w => w.Contains("var imageSrc"));
            return ExtractValue(imageUrlSection, new Regex("var imageSrc = '([a-z0-9/.]*)';", RegexOptions.IgnoreCase));
        }

        private DateTime? GetPostedDate(IShot shot)
        {
            DateTime date;
            var sectionDate = document.GetElementbyId("hidden_date").InnerText;
            if (DateTime.TryParse(sectionDate, out date))
                shot.PostedDate = date;
            return date;
        }

        private string GetPostedBy()
        {
            return document.GetElementbyId("postername")
                                    .Descendants("a")
                                    .FirstOrDefault()
                                    .InnerText;
        }

        private int? GetNumberOfSolver(HtmlAgilityPack.HtmlNode sectionShotInfo)
        {
            var sectionNbSolved = sectionShotInfo.Descendants("li")
                                                 .FirstOrDefault(li => li.Attributes.Any(attr => attr.Name == "class" && attr.Value == "solved"))
                                                 .InnerText;
            return ExtractAndParseInt(sectionNbSolved, new Regex(@"status: solved \((\d*)\)")).GetValueOrDefault(0);
        }

        private string GetFirstSolver(HtmlAgilityPack.HtmlNode sectionShotInfo)
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

            var isFavouriteOnclickContent = document.GetElementbyId("favbutton")
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

        private List<string> GetLanguages(HtmlAgilityPack.HtmlNode sectionSolution)
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
            return document.GetElementbyId("shot_tag_list")
                           .Descendants("a")
                           .Where(a => a.Attributes.Any(attr => attr.Name == "href" && attr.Value.StartsWith("/search?t=tag")))
                           .Select(s => s.InnerText)
                           .ToList();
        }

        private int GetNumberOfFavourited()
        {
            int numberOfFavourited = 0;

            var numberOfFavouritedSection = document.GetElementbyId("shot_tags")
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
    }
}
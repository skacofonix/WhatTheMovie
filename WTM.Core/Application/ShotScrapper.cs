using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WTM.Core.Application.Scrapper;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application
{
    public class ShotScrapper : BaseScrapper
    {
        private const string identifier = "shot";
        private readonly Regex regexCleanHtml = new Regex(@"[\r\t\n ]");
        private readonly Regex regexShotId = new Regex(@"/shot/(\d*)");
        private readonly Regex regexNumber = new Regex(@"([0-9]*)", RegexOptions.IgnorePatternWhitespace);

        private int parameterShotId;
        
        public Shot Scrap(int id)
        {
            parameterShotId = id;

            var shot = new Shot();

            base.ReceiveHtmlDocument();

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
                shot.PostedBy = GetPostedBy();

                var sectionShotInfo = document.GetElementbyId("main_shot")
                                              .Descendants("ul")
                                              .FirstOrDefault(ul => ul.Attributes.Any(attr => attr.Name == "class" && attr.Value == "nav_shotinfo"));
                shot.NbSolver = GetNumberOfSolver(sectionShotInfo);
                shot.FirstSolver = GetFirstSolver(sectionShotInfo);

                var sectionSolution = document.GetElementbyId("solve_station");
                shot.Languages = GetLanguages(sectionSolution);
            }
            catch (Exception ex)
            {
                throw;
            }

            return shot;
        }

        private int GetFirstShotId()
        {
            var firstShotIdLink = document.GetElementbyId("first_shot_link")
                                          .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(firstShotIdLink, regexShotId).GetValueOrDefault();
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

        private int GetCurrentShotId()
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

        private int GetLastShotId()
        {
            var LastShotIdLink = document.GetElementbyId("last_shot_link")
                                         .GetAttributeValue("href", string.Empty);
            return ExtractAndParseInt(LastShotIdLink, regexShotId).Value;
        }

        private string GetImageUrl(Shot shot)
        {
            var imageUrlSection = document.DocumentNode.Descendants("script")
                                                       .Where(s => s.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                       .Select(s => s.InnerText)
                                                       .FirstOrDefault(w => w.Contains("var imageSrc"));
            return ExtractValue(imageUrlSection, new Regex("var imageSrc = '([a-z0-9/.]*)';", RegexOptions.IgnoreCase));
        }

        private DateTime GetPostedDate(Shot shot)
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

        private int GetNumberOfSolver(HtmlAgilityPack.HtmlNode sectionShotInfo)
        {
            var sectionNbSolved = sectionShotInfo.Descendants("li")
                                                 .FirstOrDefault(li => li.Attributes.Any(attr => attr.Name == "class" && attr.Value == "solved"))
                                                 .InnerText;
            return ExtractAndParseInt(sectionNbSolved, new Regex(@"status: solved \((\d*)\)")).Value;
        }

        private string GetFirstSolver(HtmlAgilityPack.HtmlNode sectionShotInfo)
        {
            return sectionShotInfo.Descendants("li")
                                  .FirstOrDefault(li => li.InnerText.StartsWith("first solved by:"))
                                  .Descendants("a")
                                  .FirstOrDefault()
                                  .InnerText;
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

        /// /////////////////////////////////////////////////:

        private string ExtractValue(string value, Regex regex)
        {
            string valueExtracted = value;

            var match = regex.Match(value);
            value = match.Groups[1].Value;

            return value;
        }

        private int? ExtractAndParseInt(string value, Regex regex)
        {
            var valueExctracted = ExtractValue(value, regex);

            if (string.IsNullOrWhiteSpace(valueExctracted))
                return null;

            int valueConverted;
            if(int.TryParse(valueExctracted, out valueConverted))
                return valueConverted;

            return null;
        }

        private DateTime ExtractAndParseDateTime(string value, Regex regex)
        {
            var valueExctracted = ExtractValue(value, regex);

            DateTime valueConverted;
            DateTime.TryParse(valueExctracted, out valueConverted);

            return valueConverted;
        }

        protected override Uri MakeUri()
        {
            var url = string.Join("/", urlRoot, identifier, parameterShotId.ToString(CultureInfo.InvariantCulture));
            var uri = new Uri(url);
            return uri;
        }

        protected override void DoWorkInternal()
        {
            throw new NotImplementedException();
        }
    }
}

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
        private string identifier = "shot";

        public Shot Scrap(double id)
        {
            var shot = new Shot();

            var url = string.Join("/", urlRoot, identifier, id.ToString(CultureInfo.InvariantCulture));
            var uri = new Uri(url);
            var webRequest = WebRequest.CreateHttp(uri);

            var asyncResult = webRequest.BeginGetResponse(new AsyncCallback(state =>
            {
            }), null);
            var webResponse = webRequest.EndGetResponse(asyncResult);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            using (var stream = webResponse.GetResponseStream())
            {
                document.Load(stream);
            }

            var regexCleanHtml = new Regex("[\r\t\n ]");

            try
            {
                var mainShot = document.GetElementbyId("main_shot");

                var navShots = document.GetElementbyId("nav_shots");

                var firstShotIdLink = document.GetElementbyId("first_shot_link")
                                              .GetAttributeValue("href", "");
                var regexShotId = new Regex(@"/shot/(\d*)");
                var matchShotId = regexShotId.Match(firstShotIdLink);
                if(matchShotId.Success)
                {
                    int firstShotId;
                    if (int.TryParse(matchShotId.Groups[1].Value, out firstShotId))
                        shot.FirstShotId = firstShotId;
                }


                // ID
                var value = navShots.ChildNodes.Where(n => n.Name == "li" && n.Attributes.Any(attr => attr.Name == "class" && attr.Value == "number"))
                                               .FirstOrDefault()
                                               .InnerText;
                var shotIdString = regexCleanHtml.Replace(value, string.Empty);
                int shotId;
                if (int.TryParse(shotIdString, out shotId))
                    shot.ShotId = shotId;

                // Image URL
                var section = document.DocumentNode.Descendants("script")
                                                   .Where(s => s.Attributes.Any(attr => attr.Name == "type" && attr.Value == "text/javascript"))
                                                   .Select(s => s.InnerText)
                                                   .FirstOrDefault(w => w.Contains("var imageSrc"));
                var regexImg = new Regex("var imageSrc = '([a-z0-9/.]*)';", RegexOptions.IgnoreCase);
                var matchImg = regexImg.Match(section);
                shot.ImageUrl = matchImg.Groups[1].Value;

                // Date
                DateTime date;
                var sectionDate = document.GetElementbyId("hidden_date").InnerText;
                if (DateTime.TryParse(sectionDate, out date))
                    shot.PostedDate = date;

                var sectionShotInfo = mainShot.Descendants("ul")
                                              .FirstOrDefault(ul => ul.Attributes.Any(attr => attr.Name == "class" && attr.Value == "nav_shotinfo"));

                // Posted by
                shot.PostedBy = document.GetElementbyId("postername").Descendants("a").FirstOrDefault().InnerText;

                // Nb solved
                var sectionNbSolved = sectionShotInfo.Descendants("li")
                                                     .FirstOrDefault(li => li.Attributes.Any(attr => attr.Name == "class" && attr.Value == "solved"))
                                                     .InnerText;
                var regexNbSolved = new Regex(@"status: solved \((\d*)\)");
                var matchNbSolved = regexNbSolved.Match(sectionNbSolved);
                if (matchNbSolved.Success)
                {
                    int nbSolved;
                    if (int.TryParse(matchNbSolved.Groups[1].Value, out nbSolved))
                        shot.NbSolver = nbSolved;
                }

                // First solved by
                shot.FirstSolver = sectionShotInfo.Descendants("li")
                                                   .FirstOrDefault(li => li.InnerText.StartsWith("first solved by:"))
                                                   .Descendants("a")
                                                   .FirstOrDefault()
                                                   .InnerText;

                var sectionSolution = document.GetElementbyId("solve_station");

                // Language
                var languageSection = sectionSolution.Descendants("form")
                                                     .FirstOrDefault()
                                                     .Descendants("ul")
                                                     .FirstOrDefault(ul => ul.Attributes.Any(attr => attr.Name == "class" && attr.Value == "language_flags"))
                                                     .Descendants("img")
                                                     .Select(img => img.Attributes.FirstOrDefault(attr => attr.Name == "src"))
                                                     .ToList();
                var regexLanguage = new Regex("//static.whatthemovie.com/images/flags/(dk).png");
                foreach (var language in languageSection)
                {
                    //var matchLanguage = regexLanguage.Match(language);
                    //matchLanguage.Groups[1].Value;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return shot;
        }

        public void SendTitle(string title)
        {
        }
    }
}

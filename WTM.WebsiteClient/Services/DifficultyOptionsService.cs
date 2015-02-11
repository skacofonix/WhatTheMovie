using System.Diagnostics;
using System.Linq;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using WTM.Domain;
using WTM.Domain.Interfaces;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Helpers;

namespace WTM.WebsiteClient.Services
{
    public class DifficultyOptionsService
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;

        public DifficultyOptionsService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        public IDifficultyOptions Read()
        {
            var stopwatch = Stopwatch.StartNew();

            var htmlDocument = GetHtmlDocument();
            if (htmlDocument == null) return null;

            var difficultyOptions = new DifficultyOptions();

            difficultyOptions.SnapshotDifficultyFilter = GetDifficulty(htmlDocument);

            GetNumberOfShotForeachDifficultyLevel(htmlDocument, difficultyOptions);

            GetTags(htmlDocument, difficultyOptions);

            GetIncludeArchive(htmlDocument, difficultyOptions);

            GetIncludeSolvedShots(htmlDocument, difficultyOptions);

            stopwatch.Stop();
            difficultyOptions.ParseDuration = new TimeSpan(stopwatch.ElapsedTicks);
            difficultyOptions.ParseDateTime = DateTime.Now;

            return difficultyOptions;
        }

        private HtmlDocument GetHtmlDocument()
        {
            var uri = new Uri(webClient.UriBase, "/shot/randomoptions");

            var webResponse = webClient.Post(uri);
            var stream = webResponse.GetResponseStream();
            if (stream == null) return null;

            string rawData;
            using (var sr = new StreamReader(stream))
            {
                rawData = sr.ReadToEnd();
            }

            var rawDataClean = rawData.CleanString();

            var match = Regex.Match(rawDataClean, "Element.update\\(\"awesome_button_config\", \"(.*)\"\\);");
            if (!match.Success) return null;

            var sb = new StringBuilder();
            sb.Append("<html><body>");
            sb.Append(match.Groups[1].Value);
            sb.Append("</body></html>");

            return htmlParser.GetHtmlDocument(sb.ToString());
        }

        private static ISnapshotDifficultyChoice GetDifficulty(HtmlDocument htmlDocument)
        {
            var easyNode = htmlDocument.GetElementbyId("difficulty_easy");
            var mediumNode = htmlDocument.GetElementbyId("difficulty_medium");
            var hardNode = htmlDocument.GetElementbyId("difficulty_hard");
            var allNode = htmlDocument.GetElementbyId("difficulty_all");

            if (easyNode != null && IsChecked(easyNode))
                return new SnapshotDifficultyChoiceEasy();
            if (mediumNode != null && IsChecked(mediumNode))
                return new SnapshotDifficultyChoiceEasyMedium();
            if (hardNode != null && IsChecked(hardNode))
                return new SnapshotDifficultyChoiceHard();
            if (allNode != null && IsChecked(allNode))
                return new SnapshotDifficultyChoiceAll();

            // TODO : Log
            return new SnapshotDifficultyChoiceEasy();
        }

        private void GetNumberOfShotForeachDifficultyLevel(HtmlDocument htmlDocument, DifficultyOptions difficultyOptions)
        {
            difficultyOptions.NumberOfShotEasy = ExtractNumberOfShot(htmlDocument,"difficulty_easy");

            var numberOfShotEasyMedium = ExtractNumberOfShot(htmlDocument, "difficulty_medium");
            if (difficultyOptions.NumberOfShotEasy.HasValue && numberOfShotEasyMedium.HasValue)
                difficultyOptions.NumberOfShotMedium = numberOfShotEasyMedium.Value - difficultyOptions.NumberOfShotEasy.Value;

            difficultyOptions.NumberOfShotHard = ExtractNumberOfShot(htmlDocument, "difficulty_hard");
        }

        private readonly Regex numberOfShotRegex = new Regex(".* (\\d*)");

        private int? ExtractNumberOfShot(HtmlDocument htmlDocument, string elementId)
        {
            var inputNode = htmlDocument.GetElementbyId(elementId);
            if (inputNode != null)
            {
                var inputLabelNode = inputNode.NextSibling;
                if (inputLabelNode != null && inputLabelNode.GetAttributeValue("for", null) == elementId)
                {
                    var inputLabelMatch = numberOfShotRegex.Match(inputLabelNode.InnerHtml);

                    if (inputLabelMatch.Success)
                    {
                        int nbSnaptshot;
                        if (int.TryParse(inputLabelMatch.Groups[1].Value, out nbSnaptshot))
                            return nbSnaptshot;
                    }
                }
            }

            return null;
        }

        private static void GetTags(HtmlDocument htmlDocument, DifficultyOptions difficultyOptions)
        {
            var keywordNode = htmlDocument.GetElementbyId("keyword");
            if (keywordNode != null)
                difficultyOptions.TagFilter = keywordNode.GetAttributeValue("value", null);
        }

        private static void GetIncludeArchive(HtmlDocument htmlDocument, DifficultyOptions difficultyOptions)
        {
            var includeArchiveNode = htmlDocument.GetElementbyId("include_archive");
            if (includeArchiveNode != null)
                difficultyOptions.IncludeArchive = IsChecked(includeArchiveNode);
        }

        private static void GetIncludeSolvedShots(HtmlDocument htmlDocument, DifficultyOptions difficultyOptions)
        {
            var includeSolvedShots = htmlDocument.GetElementbyId("include_solvedshots");
            if (includeSolvedShots != null)
                difficultyOptions.IncludeSolvedShots = IsChecked(includeSolvedShots);
        }

        private static bool IsChecked(HtmlNode htmlNode)
        {
            const string checkedTag = "checked";
            return htmlNode.GetAttributeValue(checkedTag, null) == checkedTag;
        }

        public bool Write(IDifficultyOptions difficultyOptions)
        {
            var uriSource = new Uri(webClient.UriBase, "/shot/1");
            var uriDestination = new Uri(webClient.UriBase, "/shot/setrandomoptions");

            var httpRequestBuilder = new HttpRequestBuilder();
            httpRequestBuilder.AddParameter("difficulty", difficultyOptions.SnapshotDifficultyFilter.ToString());
            httpRequestBuilder.AddParameter("keyword", difficultyOptions.TagFilter);
            httpRequestBuilder.AddParameter("include_archive", difficultyOptions.IncludeArchive ? "1" : "0");
            httpRequestBuilder.AddParameter("include_solved", difficultyOptions.IncludeSolvedShots ? "1" : "0");
            var data = httpRequestBuilder.ToString();

            webClient.Post(uriSource, uriDestination, data);

            return false;
        }
    }
}
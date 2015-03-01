using System.Net;
using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using WTM.Crawler.Helpers;
using WTM.Domain;
using WTM.Domain.Interfaces;
using WTM.Crawler.Extensions;

namespace WTM.Crawler.Services
{
    public class RandomOptionsService : IReadWriteService<IDifficultyOptions>
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;

        public RandomOptionsService(IWebClient webClient, IHtmlParser htmlParser)
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

            var webResponse = webClient.Post(uriSource, uriDestination, data) as HttpWebResponse;
            return webResponse != null && webResponse.StatusCode == HttpStatusCode.OK;
        }

        private HtmlDocument GetHtmlDocument()
        {
            var uri = new Uri(webClient.UriBase, "/shot/randomoptions");
            var asyncWebRequest = new AsyncWebRequest(webClient, htmlParser);
            return asyncWebRequest.DoAsyncPostRequest(uri);
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

            return null;
        }

        private void GetNumberOfShotForeachDifficultyLevel(HtmlDocument htmlDocument, DifficultyOptions difficultyOptions)
        {
            difficultyOptions.NumberOfShotEasy = ExtractNumberOfShot(htmlDocument, "difficulty_easy");

            var numberOfShotEasyMedium = ExtractNumberOfShot(htmlDocument, "difficulty_medium");
            if (difficultyOptions.NumberOfShotEasy.HasValue && numberOfShotEasyMedium.HasValue)
                difficultyOptions.NumberOfShotMedium = numberOfShotEasyMedium.Value - difficultyOptions.NumberOfShotEasy.Value;

            var numberOfShotAll = ExtractNumberOfShot(htmlDocument, "difficulty_all");
            if (numberOfShotEasyMedium.HasValue && numberOfShotAll.HasValue)
                difficultyOptions.NumberOfShotHard = numberOfShotAll - numberOfShotEasyMedium;
        }

        private readonly Regex numberOfShotRegex = new Regex(".* \\((\\d*)\\)");

        private int? ExtractNumberOfShot(HtmlDocument htmlDocument, string elementId)
        {
            var inputLabelNode = htmlDocument.DocumentNode.SelectSingleNode(string.Format("//label[@for='{0}']", elementId));
            if (inputLabelNode == null) return null;

            var inputLabelMatch = numberOfShotRegex.Match(inputLabelNode.InnerHtml);
            if (!inputLabelMatch.Success) return null;

            int nbSnaptshot;
            if (int.TryParse(inputLabelMatch.Groups[1].Value, out nbSnaptshot))
                return nbSnaptshot;

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
            return htmlNode.GetAttributeValue(checkedTag, null) != null;
        }
    }
}
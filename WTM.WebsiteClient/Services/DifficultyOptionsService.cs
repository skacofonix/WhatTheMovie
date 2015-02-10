using HtmlAgilityPack;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using WTM.Domain;
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

        public DifficultyOptions Read()
        {
            var difficultyOptions = new DifficultyOptions();

            var htmlDocument = GetHtmlDocument();
            if (htmlDocument == null) return null;

            difficultyOptions.SnapshotDifficultyFilter = GetDifficulty(htmlDocument);

            var keywordNode = htmlDocument.GetElementbyId("keyword");
            if (keywordNode != null)
                difficultyOptions.TagFilter = keywordNode.GetAttributeValue("value", null);

            var includeArchiveNode = htmlDocument.GetElementbyId("include_archive");
            if (includeArchiveNode != null)
                difficultyOptions.IncludeArchive = IsChecked(includeArchiveNode);

            var includeSolvedShots = htmlDocument.GetElementbyId("include_solvedshots");
            if (includeSolvedShots != null)
                difficultyOptions.IncludeSolvedShots = IsChecked(includeSolvedShots);

            return difficultyOptions;
        }

        private HtmlDocument GetHtmlDocument()
        {
            var uri = new Uri(webClient.UriBase + "/shot/randomoptions");

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

        private static SnapshotDifficulty GetDifficulty(HtmlDocument htmlDocument)
        {
            var easyNode = htmlDocument.GetElementbyId("difficulty_easy");
            var mediumNode = htmlDocument.GetElementbyId("difficulty_medium");
            var hardNode = htmlDocument.GetElementbyId("difficulty_hard");
            var allNode = htmlDocument.GetElementbyId("difficulty_all");

            if (easyNode != null && IsChecked(easyNode))
                return SnapshotDifficulty.Easy;
            if (mediumNode != null && IsChecked(mediumNode))
                return SnapshotDifficulty.Easy | SnapshotDifficulty.Medium;
            if (hardNode != null && IsChecked(hardNode))
                return SnapshotDifficulty.Hard;
            if (allNode != null && IsChecked(allNode))
                return SnapshotDifficulty.Easy | SnapshotDifficulty.Medium | SnapshotDifficulty.Hard;

            // TODO : Log
            return SnapshotDifficulty.Easy;
        }

        private static bool IsChecked(HtmlNode htmlNode)
        {
            const string checkedTag = "checked";
            return htmlNode.GetAttributeValue(checkedTag, null) == checkedTag;
        }

        public bool Write()
        {
            return false;
        }
    }
}
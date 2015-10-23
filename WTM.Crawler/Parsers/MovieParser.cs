using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using HtmlAgilityPack;
using WTM.Crawler.Domain;
using WTM.Crawler.Extensions;

namespace WTM.Crawler.Parsers
{
    internal class MovieParser : ParserBase<Movie>
    {
        protected override string Identifier { get { return "movie"; } }

        public MovieParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public Movie GetById(string title)
        {
            var movie = base.Parse(title);

            var baseUri = base.MakeUri(title);

            var movieInfoHtmlDocument = GetMovieInfo(baseUri);

            if (movieInfoHtmlDocument == null)
                return movie;

            var navigator = movieInfoHtmlDocument.CreateNavigator();

            movie.AlternativeTitles = GetTitles(baseUri, movieInfoHtmlDocument, navigator);
            movie.Tags = GetTags(baseUri, movieInfoHtmlDocument, navigator);

            ParseStats(navigator, movie);

            return movie;
        }

        protected override void ParseHtmlDocument(Movie movie, HtmlDocument document)
        {
            var navigator = document.CreateNavigator();
            if (navigator == null) return;

            var nodeTitle = navigator.SelectSingleNode("//div[@class='header clearfix']/h1");
            if (nodeTitle != null)
            {
                var regexTitle = new Regex("(.*)<span>\\((\\d{4})\\)</span>");
                var match = regexTitle.Match(nodeTitle.InnerXml);

                movie.OriginalTitle = match.Groups[1].Value;

                int year;
                if (int.TryParse(match.Groups[2].Value, out year))
                    movie.Year = year;
            }

            var genreList = new List<string>();
            var nodeGenre = navigator.Select("//div[@id='main_white']/div[@class='col_left nopadding']/div[@class='shot_focus_box']/div[@class='movie_info clearfix']/ul[@class='info_list']/li[@class='clearfix'][1]/ul[@class='clearfix']/li");
            if (nodeGenre.Count > 0)
            {
                while (nodeGenre.MoveNext())
                    genreList.Add(nodeGenre.Current.InnerXml);
                movie.GenreList = genreList;
            }

            var nodeDirector = navigator.SelectSingleNode("//div[@id='main_white']/div[@class='col_left nopadding']/div[@class='shot_focus_box']/div[@class='movie_info clearfix']/ul[@class='info_list']/li[@class='clearfix'][2]/ul[@class='clearfix']/li");
            if (nodeDirector != null)
                movie.Director = nodeDirector.InnerXml;

            var nodeAbstract = navigator.SelectSingleNode("//p[@class='movie_abstract']");
            if (nodeAbstract != null)
                movie.Abstract = nodeAbstract.InnerXml.CleanString();

            var rate = new Rate();

            var nodeRate = navigator.SelectSingleNode("//div[@class='movie_rating clearfix']");
            if (nodeRate == null) return;
            var nodeNumberOfRate = nodeRate.SelectSingleNode("./h4/span");
            if (nodeNumberOfRate != null)
            {
                var matchNumberOfRate = Regex.Match(nodeNumberOfRate.InnerXml, "\\((\\d*) votes\\)");
                int numberOfRate;
                if (int.TryParse(matchNumberOfRate.Groups[1].Value, out numberOfRate))
                    rate.NbRaters= numberOfRate;
            }

            var nodeRateNote = nodeRate.SelectSingleNode("./strong");
            if (nodeRateNote == null) return;
            var matchRateNote = Regex.Match(nodeRateNote.InnerXml, "(\\d.\\d*) / 10");

            var culture = new CultureInfo("en-US");

            decimal rateNote;
            if (decimal.TryParse(matchRateNote.Groups[1].Value, NumberStyles.Number, culture.NumberFormat, out rateNote))
                rate.Score = rateNote;

            movie.Rate = rate;
        }

        private static void ParseStats(XPathNavigator navigator, Movie movie)
        {
            var statsRootNode =
                navigator.SelectSingleNode(
                    "//div[@id='main_white']/div[@class='col_right nopadding']/div[@class='box_blank last']/div[@class='box_black']/ul[@class='stats clearfix']");

            if(statsRootNode == null)
                return;

            var numberOfSnapshotNode = statsRootNode.SelectSingleNode("./li[1]/strong");
            int numberOfSnaphot;
            if (numberOfSnapshotNode != null && int.TryParse(numberOfSnapshotNode.InnerXml, out numberOfSnaphot))
                movie.NumberOfSnapshot = numberOfSnaphot;

            var totalSolvesNode = statsRootNode.SelectSingleNode("./li[2]/strong");
            double totalSolves;
            if (totalSolvesNode != null && double.TryParse(totalSolvesNode.InnerXml, out totalSolves))
                movie.TotalSolves = totalSolves;

            var introducedByNode = statsRootNode.SelectSingleNode("./li[3]/span/a[@class='nametaglink']");
            if (introducedByNode != null) movie.IntroducedBy = introducedByNode.InnerXml;

            var introducedOnNode = statsRootNode.SelectSingleNode("li[4]/span");
            DateTime introducedOn;
            if (introducedOnNode != null && DateTime.TryParse(introducedOnNode.InnerXml, out introducedOn))
                movie.IntroducedOn = introducedOn;

            var numberOfReviewsNode = statsRootNode.SelectSingleNode("./li[@class='last']/span");
            int numberOfReviews;
            if (numberOfReviewsNode != null && int.TryParse(numberOfReviewsNode.InnerXml, out numberOfReviews))
                movie.NumberOfReviews = numberOfReviews;
        }

        private HtmlDocument GetMovieInfo(Uri baseUri)
        {
            HtmlDocument movieInfoHtmlDocument;

            var movieInfo = new Uri(baseUri + "/info");
            using (var stream = WebClient.GetStream(movieInfo))
            {
                movieInfoHtmlDocument = HtmlParser.GetHtmlDocument(stream);
            }
            return movieInfoHtmlDocument;
        }

        private List<string> GetTitles(Uri baseUri, HtmlDocument movieInfoHtmlDocument, XPathNavigator navigator)
        {
            var titleList = new List<string>();

            var titlesUri = new Uri(baseUri + "/titles");
            var titlesWebResponse = WebClient.Post(titlesUri);
            string titlesRawData = null;
            using (var stream = titlesWebResponse.GetResponseStream())
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                        titlesRawData = reader.ReadToEnd();

            if (string.IsNullOrEmpty(titlesRawData))
                return titleList;

            var titlesNode = movieInfoHtmlDocument.GetElementbyId("movie_title_list");
            var titlesMatches = Regex.Match(titlesRawData, "^Element.update\\(\"movie_title_list\", \"(.*)\"\\);$");
            titlesNode.InnerHtml = titlesMatches.Groups[1].Value;

            var titleNodeIterator = navigator.Select("//ul[@id='movie_title_list']/li");
            while (titleNodeIterator.MoveNext())
                titleList.Add(titleNodeIterator.Current.TypedValue.ToString().CleanString());

            return titleList;
        }

        private List<string> GetTags(Uri baseUri, HtmlDocument movieInfoHtmlDocument, XPathNavigator navigator)
        {
            var tagList = new List<string>();

            var tagsUri = new Uri(baseUri + "/tags");
            var tagsWebResponse = WebClient.Post(tagsUri);
            string tagsRawData = null;
            using (var stream = tagsWebResponse.GetResponseStream())
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                        tagsRawData = reader.ReadToEnd();

            if (string.IsNullOrEmpty(tagsRawData))
                return tagList;

            var tagsNode = movieInfoHtmlDocument.GetElementbyId("movie_tag_list");
            var tagsMatches = Regex.Match(tagsRawData, "^Element.update\\(\"movie_tag_list\", \"(.*)\"\\);$");
            tagsNode.InnerHtml = tagsMatches.Groups[1].Value;

            var tagNodeIterator = navigator.Select("//ul[@id='movie_tag_list']/li/a");
            while (tagNodeIterator.MoveNext())
                tagList.Add(tagNodeIterator.Current.InnerXml.CleanString());

            return tagList;
        }
    }
}
using System.Globalization;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
{
    internal class MovieParser : ParserBase<Movie>
    {
        public override string Identifier { get { return "movie"; } }

        private readonly Regex regexCleanHtml = new Regex(@"[\r\t\n]");

        public MovieParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public Movie Parse(string title)
        {
            return base.Parse(title);
        }

        protected override void Parse(Movie movie, HtmlDocument document)
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
                movie.Abstract = regexCleanHtml.Replace(nodeAbstract.InnerXml, string.Empty);

            var nodeRate = navigator.SelectSingleNode("//div[@class='movie_rating clearfix']");
            if (nodeRate != null)
            {
                var nodeNumberOfRate = nodeRate.SelectSingleNode("./h4/span");
                if (nodeNumberOfRate != null)
                {
                    var matchNumberOfRate = Regex.Match(nodeNumberOfRate.InnerXml, "\\((\\d*) votes\\)");
                    int numberOfRate;
                    if (int.TryParse(matchNumberOfRate.Groups[1].Value, out numberOfRate))
                        movie.NumberOfRate = numberOfRate;
                }

                var nodeRateNote = nodeRate.SelectSingleNode("./strong");
                if (nodeRateNote != null)
                {
                    var matchRateNote = Regex.Match(nodeRateNote.InnerXml, "(\\d.\\d*) / 10");

                    var culture = new CultureInfo("en-US");

                    decimal rateNote;
                    if (decimal.TryParse(matchRateNote.Groups[1].Value, NumberStyles.Number, culture.NumberFormat, out rateNote))
                        movie.Rate = rateNote;
                }
            }
        }
    }
}

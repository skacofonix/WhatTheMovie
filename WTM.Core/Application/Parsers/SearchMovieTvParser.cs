using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Helpers;

namespace WTM.Core.Application.Parsers
{
    internal class SearchMovieTvParser : SearchBaseParser<SearchResultCollection>
    {
        protected override string SearchIdentifier { get { return "movie"; } }

        public SearchMovieTvParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected override void ParseHtmlDocument(SearchResultCollection instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
                return;

            var regexTitle = new Regex("\"(.*)\" <span>(\\d{4})</span>");

            instance.Items = new List<SearchResultMovieTv>();

            var rootNode = navigator.Select("//ul[@class='thumbnail_list clearfix']/li[@class='thumb']/div");
            while (rootNode.MoveNext())
            {
                var searchMovie = new SearchResultMovieTv();
                instance.Items.Add(searchMovie);

                var titleNode = rootNode.Current.SelectSingleNode("./h2");
                if (titleNode != null)
                {
                    var titleMatch = regexTitle.Match(titleNode.InnerXml.CleanString());
                    if (titleMatch.Success)
                    {
                        searchMovie.Title = titleMatch.Groups[1].Value;

                        int year;
                        if (int.TryParse(titleMatch.Groups[2].Value, out year))
                            searchMovie.Year = year;
                    }
                }

                var movieUrl = rootNode.Current.SelectSingleNode("./a/@href");
                if (movieUrl != null)
                    searchMovie.MovieUrl = movieUrl.InnerXml;
            }
        }
    }
}

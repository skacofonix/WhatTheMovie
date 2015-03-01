using System.Linq;
using WTM.Core.Services;
using WTM.Crawler.Parsers;
using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Crawler.Services
{
    internal class MovieService : IMovieService
    {
        private readonly MovieParser movieParser;
        private readonly SearchMovieTvParser movieSearcher;

        public MovieService(IWebClient webClient, IHtmlParser htmlParser)
        {
            movieParser = new MovieParser(webClient, htmlParser);
            movieSearcher = new SearchMovieTvParser(webClient, htmlParser);
        }

        public IMovie GetByTitle(string title)
        {
            return movieParser.GetById(title);
        }

        public IMovieSummaryCollection Search(string title, int? page)
        {
            var result = movieSearcher.Search(title, page);

            IMovieSummaryCollection movieSummaryCollection = new MovieSummaryCollection
            {
                Movies = result.Items.Cast<IMovieSummary>().ToList()
            };

            return movieSummaryCollection;
        }
    }
}
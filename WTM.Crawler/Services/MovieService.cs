using System.Linq;
using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieParser movieParser;
        private readonly SearchMovieTvParser movieSearcher;

        public MovieService(IWebClient webClient, IHtmlParser htmlParser)
        {
            movieParser = new MovieParser(webClient, htmlParser);
            movieSearcher = new SearchMovieTvParser(webClient, htmlParser);
        }

        public Movie GetById(string id)
        {
            return movieParser.Get(id);
        }

        public MovieSummaryCollection Search(string title, int? page = null)
        {
            var result = movieSearcher.Search(title, page);

            var movieSummaryCollection = new MovieSummaryCollection
            {
                Movies = result.Items.Cast<MovieSummary>().ToList()
            };

            return movieSummaryCollection;
        }
    }
}
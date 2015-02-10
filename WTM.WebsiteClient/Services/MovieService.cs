using System.Collections.Generic;
using System.Linq;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.Interfaces;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.WebsiteClient.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;
        private readonly MovieParser movieParser;
        private readonly SearchMovieTvParser movieSearcher;

        public MovieService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
            movieParser = new MovieParser(webClient, htmlParser);
            movieSearcher = new SearchMovieTvParser(webClient, htmlParser);
        }

        public Movie GetById(string id)
        {
            return movieParser.GetById(id);
        }

        public IMovie GetByTitle(string title)
        {
            return movieParser.GetById(title);
        }

        public IMovieSummaryCollection Search(string title)
        {
            var result = movieSearcher.Search(title);

            IMovieSummaryCollection movieSummaryCollection = new MovieSummaryCollection
            {
                Movies = result.Items.Cast<IMovieSummary>().ToList()
            };

            return movieSummaryCollection;
        }
    }
}
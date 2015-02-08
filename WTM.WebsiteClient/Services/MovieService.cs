using System.Collections.Generic;
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

        public MovieService (IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
            movieParser = new MovieParser(webClient, htmlParser);
        }

        public Movie GetById(string id)
        {
            return movieParser.GetById(id);
        }

        public IMovie GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IMovieSummary> Search(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
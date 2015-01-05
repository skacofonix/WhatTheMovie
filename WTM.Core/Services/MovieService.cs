using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal class MovieService
    {
        private readonly IWebClient webClient;
        private readonly MovieParser movieParser;

        public MovieService (IWebClient webClient)
        {
            this.webClient = webClient;
            movieParser = new MovieParser();
        }

        public Movie GetById(string id)
        {
            return movieParser.Parse(id);
        }
    }
}

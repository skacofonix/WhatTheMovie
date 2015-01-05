using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal class MovieService
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
            return movieParser.Parse(id);
        }
    }
}

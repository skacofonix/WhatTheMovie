using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Services
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
            return movieParser.GetById(id);
        }
    }
}

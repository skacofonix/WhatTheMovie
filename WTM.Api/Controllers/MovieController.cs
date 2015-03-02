using System.Net;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieService movieService;

        public MovieController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            movieService = new MovieService(webClient, htmlParser);
        }

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET api/movie/{title}
        [Route("api/movie/{title}")]
        public Movie Get(string title)
        {
            var titleDecoded = WebUtility.UrlDecode(title);
            return movieService.GetByTitle(titleDecoded);
        }

        // GET api/movie/?????
        public MovieSummaryCollection Search(string title, int? page = null)
        {
            var titleDecoded = WebUtility.UrlDecode(title);
            return movieService.Search(titleDecoded, page);
        }
    }
}

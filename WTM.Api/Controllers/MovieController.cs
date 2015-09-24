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

        // GET api/Movie/{id}
        public Movie Get(string id)
        {
            return movieService.GetById(id);
        }

        // GET api/Movie?search={search}&page={page}
        [HttpGet]
        public MovieSummaryCollection Search(string search, [FromUri]int? page = null)
        {
            return movieService.Search(search, page);
        }
    }
}
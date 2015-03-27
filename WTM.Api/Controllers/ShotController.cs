using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotController : ApiController
    {
        private readonly IShotService shotService;

        public ShotController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            shotService = new ShotService(webClient, htmlParser);
        }

        public ShotController(IShotService shotService)
        {
            this.shotService = shotService;
        }

        // GET api/Shot?token={token}
        public Shot Get(string token = null)
        {
            return shotService.GetRandomShot(token);
        }

        // GET api/Shot/{id}?token={token}
        public Shot Get(int id, string token = null)
        {
            return shotService.GetById(id, token);
        }

        // GET api/Shot/{id}?guessTitle={guessTitle}&token={token}
        [HttpGet]
        public GuessTitleResponse Guess(int id, [FromUri]string guessTitle, [FromUri]string token = null)
        {
            return shotService.GuessTitle(id, guessTitle, token);
        }

        // GET Api/Shot/{id}/solution?token={token}
        [Route("Api/Shot/{id}/solution")]
        public GuessTitleResponse GetSolution(int id, [FromUri]string token = null)
        {
            return shotService.GetSolution(id, token);
        }

        // GET api/Shot/{id}?rate={rate}&token={token}
        [HttpGet]
        public Rate Rate(int id, [FromUri]int rate, [FromUri]string token = null)
        {
            return shotService.Rate(id, rate, token);
        }

        // GET api/Shot?search={search}&page={page}&token={token}
        [HttpGet]
        public ShotSummaryCollection Search(string search, [FromUri] int? page, [FromUri]string token = null)
        {
            return shotService.Search(search, page, token);
        }
    }
}
using System.Net;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Crawler;
using WTM.Crawler.Services;

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

        // GET api/Shot
        public Shot Get()
        {
            return shotService.GetRandomShot();
        }

        // GET api/Shot/{id}
        public Shot Get(int id)
        {
            return shotService.GetShotById(id);
        }

        // GET api/Shot/{id}?guessTitle={guessTitle}
        [HttpGet]
        public GuessTitleResponse Guess(int id, [FromUri]string guessTitle)
        {
            return shotService.GuessTitle(id, WebUtility.UrlDecode(guessTitle));
        }

        // GET api/Shot/{id}/solution
        [Route("Api/Shot/{id}/solution")]
        public GuessTitleResponse GetSolution(int id)
        {
            return shotService.ShowSolution(id);
        }

        // GET api/Shot/{id}?rate={rate}
        [HttpGet]
        public Rate Rate(int id, [FromUri]int rate)
        {
            return shotService.Rate(id, rate);
        }
    }
}
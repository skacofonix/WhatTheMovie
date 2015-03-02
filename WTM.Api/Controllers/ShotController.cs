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

        // POST api/Shot/{id}
        public GuessTitleResponse Guess(int id, [FromBody]string title)
        {
            return shotService.GuessTitle(id, WebUtility.UrlDecode(title));
        }

        [HttpGet]
        public GuessTitleResponse SHowSolution(int id)
        {
            return shotService.ShowSolution(id);
        }

        // POST api/Shot/{id}
        public Rate Rate(int id, [FromBody]int rate)
        {
            return shotService.Rate(id, rate);
        }

    }
}
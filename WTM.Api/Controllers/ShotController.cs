using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotController : BaseController
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
        public ShotResponse Get(string token = null)
        {
            return DoWork(() =>
            {
                var shotResponse = new ShotResponse();

                var shot = shotService.GetRandomShot(token);

                if (shot != null)
                {
                    shotResponse.Shot = shot;
                }
                else
                {
                    shotResponse.AddError(new Error
                    {
                        Message = "This shot doesn't exist"
                    });
                }

                return shotResponse;
            });
        }

        // GET api/Shot/{id}?token={token}
        public ShotResponse Get(int id, string token = null)
        {
            return DoWork(() =>
            {
                var shotResponse = new ShotResponse();

                var shot = shotService.GetRandomShot(token);

                if (shot != null)
                {
                    shotResponse.Shot = shot;
                }
                else
                {
                    shotResponse.AddError(new Error
                    {
                        Message = "This shot doesn't exist"
                    });
                }

                return shotResponse;
            });
        }

        // GET api/Shot/{id}?guessTitle={guessTitle}&token={token}
        [HttpGet]
        public ShotGuessTitleResponse Guess(int id, [FromUri]string guessTitle, [FromUri]string token = null)
        {
            return DoWork(() =>
            {
                var response = new ShotGuessTitleResponse();

                var guessTitleResponse = shotService.GuessTitle(id, guessTitle, token);

                if (guessTitleResponse != null)
                {
                    response.GuessTitleResponse = guessTitleResponse;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "Error occur"
                    });
                }

                return response;
            });

        }

        // GET Api/Shot/{id}/solution?token={token}
        [Route("Api/Shot/{id}/solution")]
        public ShotGuessTitleResponse GetSolution(int id, [FromUri]string token = null)
        {
            return DoWork(() =>
            {
                var response = new ShotGuessTitleResponse();

                var guessTitleResponse = shotService.GetSolution(id, token);

                if (guessTitleResponse != null)
                {
                    response.GuessTitleResponse = guessTitleResponse;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "Error occur"
                    });
                }

                return response;
            });
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
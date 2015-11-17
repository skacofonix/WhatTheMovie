using WTM.Domain;
using WTM.Domain.Response;

namespace WTM.RestApi.Services
{
    public class ShotService : IShotService
    {
        private readonly Crawler.Services.IShotService crawlerShotService;

        public ShotService(Crawler.Services.IShotService crawlerShotService)
        {
            this.crawlerShotService = crawlerShotService;
        }

        public ShotResponse GetById(int id, string token = null)
        {
            var shotPage = this.crawlerShotService.GetById(id, token);

            var shotdaptee = new ShotAdapter(shotPage);

            var shotResponse = new ShotResponse(shotdaptee);

            return shotResponse;
        }

        public ShotResponse GetRandom(string token = null)
        {
            var shotPage = this.crawlerShotService.GetRandomShot(token);

            var shotAdaptee = new ShotAdapter(shotPage);

            var shotResponse = new ShotResponse(shotAdaptee);

            return shotResponse;
        }

        public ShotSolutionResponse GetSolution(int id, string token = null)
        {
            var guessTitleResponsePage = this.crawlerShotService.GetSolution(id, token);

            var shotSolutionAdaptee = new ShotSolutionAdapter(guessTitleResponsePage);

            var shotSolutionResponse = new ShotSolutionResponse(shotSolutionAdaptee);

            return shotSolutionResponse;
        }

        public ShotGuessSolutionResponse GuessSolution(int id, string title, string token = null)
        {
            var guessTitleResponsePage = this.crawlerShotService.GuessTitle(id, title, token);

            var shotGuessSolutionAdaptee = new ShotGuessSolutionAdapter(guessTitleResponsePage);

            var shotGuessSolutionResponse = new ShotGuessSolutionResponse(shotGuessSolutionAdaptee);

            return shotGuessSolutionResponse;
        }
    }
}

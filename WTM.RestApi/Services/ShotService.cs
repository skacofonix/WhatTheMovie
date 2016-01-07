using WTM.RestApi.Models;

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

        public IShotGuessSolution GuessSolution(int id, GuessSolutionRequest reques)
        {
            var guessTitleResponsePage = this.crawlerShotService.GuessTitle(id, reques.Title, reques.Token);

            var shotGuessSolutionAdaptee = new ShotGuessSolutionAdapter(guessTitleResponsePage);

            return shotGuessSolutionAdaptee;
        }
    }
}

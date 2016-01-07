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

        public IShotResponse GetById(int id, ShotRequest request)
        {
            var shotPage = this.crawlerShotService.GetById(id, request.Token);

            var shotdaptee = new ShotAdapter(shotPage);

            var shotResponse = new ShotResponse(shotdaptee);

            return shotResponse;
        }

        public IShotResponse GetRandom(ShotRandomRequest request)
        {
            var shotPage = this.crawlerShotService.GetRandomShot(request.Token);

            var shotAdaptee = new ShotAdapter(shotPage);

            var shotResponse = new ShotResponse(shotAdaptee);

            return shotResponse;
        }

        public IShotGuessSolution GuessSolution(int id, GuessSolutionRequest reques)
        {
            var guessTitleResponsePage = this.crawlerShotService.GuessTitle(id, reques.Title, reques.Token);

            var shotGuessSolutionAdaptee = new ShotGuessSolutionAdapter(guessTitleResponsePage);

            return shotGuessSolutionAdaptee;
        }

        public IShotSolutionResponse GetSolution(int id, ShotSolutionRequest request)
        {
            var guessTitleResponsePage = this.crawlerShotService.GetSolution(id, request.Token);

            var shotSolutionAdaptee = new ShotSolutionAdapter(guessTitleResponsePage);

            var shotSolutionResponse = new ShotSolutionResponse(shotSolutionAdaptee);

            return shotSolutionResponse;
        }
    }
}
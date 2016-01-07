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

        public IShotGuessTitleResponse GuessTitle(int id, GuessSolutionRequest reques)
        {
            var guessTitleResponsePage = this.crawlerShotService.GuessTitle(id, reques.Title, reques.Token);

            var shotGuessSolutionAdaptee = new ShotGuessTitleResponse(guessTitleResponsePage);

            return shotGuessSolutionAdaptee;
        }

        public IShotSolutionResponse GetSolution(int id, ShotSolutionRequest request)
        {
            var solutionTitleResponse = this.crawlerShotService.GetSolution(id, request.Token);

            var result = new ShotSolutionResponse(solutionTitleResponse);

            return result;
        }
    }
}
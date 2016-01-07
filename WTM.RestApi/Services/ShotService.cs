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
            var shotPage = this.crawlerShotService.GetById(id, request?.Token);

            return new ShotResponse(shotPage);
        }

        public IShotResponse GetRandom(ShotRandomRequest request)
        {
            var shotPage = this.crawlerShotService.GetRandomShot(request?.Token);

            return new ShotResponse(shotPage);
        }

        public IShotGuessTitleResponse GuessTitle(int id, GuessSolutionRequest reques)
        {
            var guessTitleResponsePage = this.crawlerShotService.GuessTitle(id, reques.Title, reques.Token);

            return new ShotGuessTitleResponse(guessTitleResponsePage);
        }

        public IShotSolutionResponse GetSolution(int id, ShotSolutionRequest request)
        {
            var solutionTitleResponse = this.crawlerShotService.GetSolution(id, request.Token);

            return new ShotSolutionResponse(solutionTitleResponse);
        }
    }
}
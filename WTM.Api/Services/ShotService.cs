using WTM.Api.Models;

namespace WTM.Api.Services
{
    public class ShotService : IShotService
    {
        private readonly Crawler.Services.IShotService crawlerShotService;

        public ShotService(Crawler.Services.IShotService crawlerShotService)
        {
            this.crawlerShotService = crawlerShotService;
        }

        public IShotResponse GetById(int id, IShotRequest request)
        {
            var shotPage = this.crawlerShotService.GetById(id, request?.Token);
            return new ShotResponse(shotPage);
        }

        public IShotResponse GetRandom(IShotRandomRequest request)
        {
            var shotPage = this.crawlerShotService.GetRandomShot(request?.Token);
            return new ShotResponse(shotPage);
        }

        public IShotGuessTitleResponse GuessTitle(int id, IGuessSolutionRequest request)
        {
            var guessTitleResponsePage = this.crawlerShotService.GuessTitle(id, request.Title, request.Token);
            return new ShotGuessTitleResponse(guessTitleResponsePage);
        }

        public IShotSolutionResponse GetSolution(int id, IShotSolutionRequest request)
        {
            var solutionTitleResponse = this.crawlerShotService.GetSolution(id, request.Token);
            return new ShotSolutionResponse(solutionTitleResponse);
        }
    }
}
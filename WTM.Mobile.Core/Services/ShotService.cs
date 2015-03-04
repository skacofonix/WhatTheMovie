using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.Services
{
    public class ShotService : IShotService
    {
        private readonly IShotService shotService;

        public ShotService()
        {
            var settings = new SettingsAzure();
            var settingsAdapter = new ApiClientSettingsAdapter(settings);
            shotService = new Api.Client.Services.ShotService(settingsAdapter);
        }

        public Shot GetRandomShot()
        {
            return shotService.GetRandomShot();
        }

        public Shot GetById(int id)
        {
            return shotService.GetById(id);
        }

        public GuessTitleResponse GuessTitle(int id, string title)
        {
            return shotService.GuessTitle(id, title);
        }

        public GuessTitleResponse GetSolution(int id)
        {
            return shotService.GetSolution(id);
        }

        public Rate Rate(int id, int score)
        {
            return shotService.Rate(id, score);
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            return shotService.Search(tag, page);
        }
    }
}
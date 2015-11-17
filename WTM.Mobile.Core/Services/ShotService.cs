using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.OldSchool;

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

        public Shot GetRandomShot(string token = null)
        {
            return shotService.GetRandomShot(token);
        }

        public Shot GetById(int id, string token = null)
        {
            return shotService.GetById(id, token);
        }

        public GuessTitleResponse GuessTitle(int id, string title, string token = null)
        {
            return shotService.GuessTitle(id, title, token);
        }

        public GuessTitleResponse GetSolution(int id, string token = null)
        {
            return shotService.GetSolution(id, token);
        }

        public Rate Rate(int id, int score, string token = null)
        {
            return shotService.Rate(id, score, token);
        }

        public ShotSummaryCollection Search(string tag, int? page = null, string token = null)
        {
            return shotService.Search(tag, page, token);
        }
    }
}
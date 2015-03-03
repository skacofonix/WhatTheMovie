using System;
using WTM.Core.Services;
using WTM.Domain;
using Settings = WTM.Api.Client.Settings;

namespace WTM.Mobile.Core.Services
{
    public class ShotService : IShotService
    {
        private IShotService shotService;

        public ShotService()
        {
            var settings = new SettingsAzure();
            var settingsAdapter = new ApiClientSettingsAdapter(settings);
            shotService = new Api.Client.Services.ShotService(settingsAdapter);
        }

        public Shot GetRandomShot()
        {
            throw new NotImplementedException();
        }

        public Shot GetShotById(int id)
        {
            throw new NotImplementedException();
        }

        public GuessTitleResponse GuessTitle(int id, string title)
        {
            throw new NotImplementedException();
        }

        public GuessTitleResponse ShowSolution(int id)
        {
            throw new NotImplementedException();
        }

        public Rate Rate(int id, int score)
        {
            throw new NotImplementedException();
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            throw new NotImplementedException();
        }
    }
}
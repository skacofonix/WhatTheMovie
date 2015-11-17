using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.OldSchool;

namespace WTM.Mobile.Core.Services
{
    public class ShotOverviewService : IShotOverviewService
    {
        private readonly IShotOverviewService shotOverviewService;

        public ShotOverviewService()
        {
            var settings = new SettingsAzure();
            var settingsAdapter = new ApiClientSettingsAdapter(settings);
            shotOverviewService = new Api.Client.Services.ShotOverviewService(settingsAdapter);
        }

        public ShotSummaryCollection GetShotSummaryByDate(DateTime date)
        {
            return shotOverviewService.GetShotSummaryByDate(date);
        }
    }
}

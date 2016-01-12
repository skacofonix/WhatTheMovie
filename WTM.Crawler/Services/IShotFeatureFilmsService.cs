using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IShotFeatureFilmsService : IShotOverviewService
    {
        ShotSummaryCollection GetShotSummaryToday(string token = null);
    }
}
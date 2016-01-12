using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IShotArchiveService : IShotOverviewService
    {
        ShotSummaryCollection GetArchiveOneMonthOld(string token = null);
    }
}
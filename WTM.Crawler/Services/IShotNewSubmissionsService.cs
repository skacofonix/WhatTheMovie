using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IShotNewSubmissionsService
    {
        ShotSummaryCollection GetShots(string token);
    }
}
using System;
using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IShotOverviewService : IShotService
    {
        ShotSummaryCollection GetShotSummaryByDate(DateTime date);
    }
}
using System;
using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IShotOverviewService
    {
        ShotSummaryCollection GetShotSummaryByDate(DateTime date);
    }
}
using System;
using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IShotOverviewService
    {
        ShotSummaryCollection GetShotSummaryByDate(DateTime date);
    }
}
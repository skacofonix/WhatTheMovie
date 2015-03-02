using System;
using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IShotOverview
    {
        ShotSummaryCollection GetShotSummaryByDate(DateTime date);
    }
}
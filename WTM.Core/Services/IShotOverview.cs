using System;
using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Core.Services
{
    public interface IShotOverview
    {
        ShotSummaryCollection GetShotSummaryByDate(DateTime date);
    }
}
using System;
using WTM.Domain.Interfaces;

namespace WTM.Core.Services
{
    public interface IShotOverview
    {
        IShotSummaryCollection GetShotSummaryByDate(DateTime date);
    }
}
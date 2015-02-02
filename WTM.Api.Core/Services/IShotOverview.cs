using System;
using System.Collections.Generic;
using WTM.Domain;

namespace WTM.Api.Core.Services
{
    public interface IShotOverview
    {
        IEnumerable<IShotSummary> GetShotSummary(DateTime date);
    }
}

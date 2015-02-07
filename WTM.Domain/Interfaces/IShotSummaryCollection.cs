using System;
using System.Collections.Generic;

namespace WTM.Domain.Interfaces
{
    public interface IShotSummaryCollection : IWebsiteEntity
    {
        DateTime? Date { get; }

        IList<IShotSummary> Shots { get;}

        ShotType? ShotType { get; }
    }
}

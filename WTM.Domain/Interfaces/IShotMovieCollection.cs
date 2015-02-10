using System;
using System.Collections.Generic;

namespace WTM.Domain.Interfaces
{
    public interface IMovieSummaryCollection : IWebsiteEntity
    {
        DateTime? Date { get; }

        IList<IMovieSummary> Movies { get; }
    }
}
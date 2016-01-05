using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public interface IShotSearchTagResponse : ISearchResult
    {
        IEnumerable<ShotSummary> Items { get; }
    }
}
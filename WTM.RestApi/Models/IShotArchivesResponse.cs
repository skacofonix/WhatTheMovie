using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public interface IShotArchivesResponse
    {
        IEnumerable<ShotSummary> Items { get; }
    }
}
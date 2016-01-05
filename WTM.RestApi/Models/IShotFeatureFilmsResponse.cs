using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public interface IShotFeatureFilmsResponse
    {
        IEnumerable<ShotSummary> Items { get; }
    }
}
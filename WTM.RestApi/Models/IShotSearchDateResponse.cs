using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public interface IShotSearchDateResponse
    {
        IEnumerable<ShotSummary> Items { get; }
    }
}
using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public interface IShotNewSubmissionsResponse
    {
        IEnumerable<ShotSummary> Items { get;  }
    }
}
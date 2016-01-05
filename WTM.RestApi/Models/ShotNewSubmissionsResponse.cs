using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public class ShotNewSubmissionsResponse : IShotNewSubmissionsResponse
    {
        public IEnumerable<ShotSummary> Items { get; private set; }

        public ShotNewSubmissionsResponse(IEnumerable<ShotSummary> items)
        {
            Items = items;
        }
    }
}
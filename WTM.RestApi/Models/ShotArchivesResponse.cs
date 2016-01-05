using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public class ShotArchivesResponse : IShotArchivesResponse
    {
        public IEnumerable<ShotSummary> Items { get; private set; }

        public ShotArchivesResponse(IEnumerable<ShotSummary> items)
        {
            this.Items = items;
        }
    }
}
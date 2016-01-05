using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagResponse : IShotSearchTagResponse
    {
        public ShotSearchTagResponse(IEnumerable<ShotSummary> shotOverviews)
        {
            this.Items = shotOverviews;
        }

        public int TotalCount { get; }
        public IRange Range { get; }
        public IEnumerable<ShotSummary> Items { get; private set; }
    }
}
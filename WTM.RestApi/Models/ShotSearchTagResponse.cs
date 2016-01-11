using System.Collections.Generic;
using System.Linq;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagResponse : IShotSearchTagResponse
    {
        public ShotSearchTagResponse(IEnumerable<Crawler.Domain.IShotSummary> crawlerShotSummaries, int startIndex, int totalCount)
        {
            this.TotalCount = totalCount;
            this.DisplayMin = startIndex;
            this.Items = crawlerShotSummaries.Select(shotSummary => new ShotSummary(shotSummary)).Cast<IShotSummary>().ToList();
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => this.Items.Count();
        public int DisplayMin { get; }
        public int DisplayMax => DisplayMin + DisplayCount;
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
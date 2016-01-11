using System.Collections.Generic;
using System.Linq;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagResponse : IShotSearchTagResponse
    {
        public ShotSearchTagResponse(IEnumerable<Crawler.Domain.IShotSummary> crawlerShotSummaries, IRange range, int totalCount)
        {
            this.TotalCount = totalCount;
            this.DisplayRange = range;
            this.Items = crawlerShotSummaries.Select(shotSummary => new ShotSummary(shotSummary)).Cast<IShotSummary>().ToList();
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => this.Items.Count();
        public IRange DisplayRange { get; private set; }
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
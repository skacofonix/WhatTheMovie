using System;
using System.Collections.Generic;
using System.Linq;

namespace WTM.RestApi.Models
{
    public class ShotSearchResponse : IShotSearchTagResponse
    {
        public ShotSearchResponse(IEnumerable<Crawler.Domain.IShotSummary> crawlerShotSummaries, int startIndex, int totalCount)
        {
            this.TotalCount = totalCount;
            this.DisplayMin = startIndex;
            this.Items = crawlerShotSummaries.Select(shotSummary => new ShotSearchTag(shotSummary)).ToList();
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => this.Items.Count();
        public int DisplayMin { get; }
        public int DisplayMax => Math.Max(0, DisplayMin + DisplayCount - 1);
        public IEnumerable<ShotSearchTag> Items { get; private set; }
    }
}
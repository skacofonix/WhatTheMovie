using System;
using System.Collections.Generic;
using System.Linq;

namespace WTM.RestApi.Models
{
    public class ShotsResponse : IShotsResponse
    {
        public ShotsResponse(DateTime date, int startIndex, int totalCount, IEnumerable<ShotSummary> items)
        {
            this.Date = date;
            this.TotalCount = totalCount;
            this.DisplayMin = startIndex;
            this.Items = items;
        }

        public DateTime Date { get; private set; }
        public int TotalCount { get; private set; }
        public int DisplayCount => Items.Count();
        public int DisplayMin { get; }
        public int DisplayMax => this.DisplayMin + this.DisplayCount;
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
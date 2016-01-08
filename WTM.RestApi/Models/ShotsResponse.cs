using System;
using System.Collections.Generic;
using System.Linq;
using WTM.RestApi.Services;

namespace WTM.RestApi.Models
{
    public class ShotsResponse : IShotsResponse
    {
        public ShotsResponse(DateTime date, IRange range, int totalCount, IEnumerable<ShotSummary> enumerable)
        {
            this.Date = date;
            this.Range = range;
            this.TotalCount = totalCount;
            this.Items = enumerable;
        }

        public DateTime Date { get; private set; }
        public int DisplayCount => Items.Count();
        public int TotalCount { get; private set; }
        public IRange Range { get; private set; }
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
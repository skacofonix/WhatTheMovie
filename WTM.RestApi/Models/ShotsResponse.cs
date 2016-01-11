using System;
using System.Collections.Generic;
using System.Linq;
using WTM.RestApi.Services;

namespace WTM.RestApi.Models
{
    public class ShotsResponse : IShotsResponse
    {
        public ShotsResponse(DateTime date, IRange displayRange, int totalCount, IEnumerable<ShotSummary> enumerable)
        {
            this.Date = date;
            this.DisplayRange = displayRange;
            this.TotalCount = totalCount;
            this.Items = enumerable;
        }

        public DateTime Date { get; private set; }
        public int DisplayCount => Items.Count();
        public int TotalCount { get; private set; }
        public IRange DisplayRange { get; private set; }
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
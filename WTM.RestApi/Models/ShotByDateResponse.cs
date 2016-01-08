using System;
using System.Collections.Generic;
using System.Linq;

namespace WTM.RestApi.Models
{
    public class ShotByDateResponse : IShotByDateResponse
    {
        public ShotByDateResponse(DateTime date, IRange range, int totalCount, IEnumerable<ShotSummary> items)
        {
            this.Date = date;
            this.Range = range;
            this.TotalCount = totalCount;
            this.Items = items;
        }

        public DateTime Date { get; private set; }
        public int DisplayCount => Items.Count();
        public int TotalCount { get; private set; }
        public IRange Range { get; private set; }
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace WTM.Api.Models
{
    public class ShotBookmarkResponse : IShotBookmarkResponse
    {
        public ShotBookmarkResponse(IEnumerable<IShotSummary> items, int startIndex, int totalCount)
        {
            this.Items = items;
        }

        public IEnumerable<IShotSummary> Items { get; private set; }
        public int TotalCount { get; private set; }
        public int DisplayCount => Items.Count();
        public int DisplayMin { get; }
        public int DisplayMax { get; }
    }
}
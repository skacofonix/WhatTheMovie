using System.Collections.Generic;
using System.Linq;

namespace WTM.RestApi.Models
{
    public class ShotBookmarkResponse : IShotBookmarkResponse
    {
        public ShotBookmarkResponse(IEnumerable<IShotSummary> items)
        {
            this.Items = items;
        }

        public IEnumerable<IShotSummary> Items { get; private set; }
        public int TotalCount { get; private set; }
        public int DisplayCount => Items.Count();
        public IRange DisplayRange { get; private set; }
    }
}
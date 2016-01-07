using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotBookmarkResponse : IShotBookmarkResponse
    {
        public ShotBookmarkResponse(IEnumerable<IShotSummary> items)
        {
            this.Items = items;
        }

        public IEnumerable<IShotSummary> Items { get; set; }
        public int TotalCount { get; }
        public IRange Range { get; }
    }
}
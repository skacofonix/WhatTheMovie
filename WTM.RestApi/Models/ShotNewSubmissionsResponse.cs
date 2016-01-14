using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotNewSubmissionsResponse : IShotCollectionResponse
    {
        public ShotNewSubmissionsResponse(IEnumerable<IShotSummary> items)
        {
            Items = items;
        }

        public int TotalCount { get; }
        public int DisplayCount { get; }
        public int DisplayMin { get; }
        public int DisplayMax { get; }
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
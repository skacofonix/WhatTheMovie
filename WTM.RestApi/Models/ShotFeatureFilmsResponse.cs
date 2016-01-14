using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotFeatureFilmsResponse : IShotCollectionResponse
    {
        public ShotFeatureFilmsResponse(IEnumerable<IShotSummary> items)
        {
            Items = items;
        }

        public int TotalCount { get; }
        public int DisplayCount { get; }
        public int DisplayMin { get; }
        public int DisplayMax { get; }
        public IEnumerable<IShotSummary> Items { private set; get; }
    }
}
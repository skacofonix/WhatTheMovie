using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public class ShotFeatureFilmsResponse : IShotFeatureFilmsResponse
    {
        public IEnumerable<ShotSummary> Items { get; private set; }

        public ShotFeatureFilmsResponse(IEnumerable<ShotSummary> items)
        {
            Items = items;
        }
    }
}
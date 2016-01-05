using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotFeatureFilmsResponse : IResponse, IShotFeatureFilmsResponse
    {
        public IEnumerable<IShotSummary> Items { get; private set; }

        public ShotFeatureFilmsResponse(IEnumerable<IShotSummary> items)
        {
            Items = items;
        }
    }
}
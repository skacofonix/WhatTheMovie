using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotNewSubmissionsResponse : IResponse, IShotNewSubmissionsResponse
    {
        public IEnumerable<IShotSummary> Items { get; private set; }

        public ShotNewSubmissionsResponse(IEnumerable<IShotSummary> items)
        {
            Items = items;
        }
    }
}
using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotArchivesResponse : IResponse, IShotArchivesResponse
    {
        public IEnumerable<IShotSummary> Items { get; private set; }

        public ShotArchivesResponse(IEnumerable<IShotSummary> items)
        {
            this.Items = items;
        }
    }
}
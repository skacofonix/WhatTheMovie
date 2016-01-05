using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotByDateResponse : IResponse, IShotByDateResponse
    {
        public IEnumerable<IShotSummary> Items { get; private set; }

        public ShotByDateResponse(IEnumerable<IShotSummary> shotOverviews)
        {
            this.Items = shotOverviews;
        }
    }
}
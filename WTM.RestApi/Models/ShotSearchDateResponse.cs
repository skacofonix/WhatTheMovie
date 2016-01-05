using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public class ShotSearchDateResponse : IShotSearchDateResponse
    {
        public IEnumerable<ShotSummary> Items { get; private set; }

        public ShotSearchDateResponse(IEnumerable<ShotSummary> shotOverviews)
        {
            this.Items = shotOverviews;
        }
    }
}
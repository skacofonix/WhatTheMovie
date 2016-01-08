using System.Collections.Generic;
using System.Linq;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagResponse : IShotSearchTagResponse
    {
        public ShotSearchTagResponse(IEnumerable<IShotSummary> shotOverviews)
        {
            this.Items = shotOverviews;
        }

        public int DisplayCount { get; private set; }
        public int TotalCount => Items.Count();
        public IRange Range { get; private set; }
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
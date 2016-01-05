using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagResponse : IResponse, IShotSearchTagResponse
    {
        public ShotSearchTagResponse(IEnumerable<IShotSummary> shotOverviews)
        {
            this.Items = shotOverviews;
        }

        public int TotalCount { get; }
        public IRange Range { get; }
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}
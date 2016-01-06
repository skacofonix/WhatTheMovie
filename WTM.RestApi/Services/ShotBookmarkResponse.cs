using System.Collections.Generic;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotBookmarkResponse : IResponse, IPaginableResult
    {
        public ShotBookmarkResponse(IEnumerable<IShotSummary> items)
        {
            this.Items = items;
        }

        public IEnumerable<IShotSummary> Items { get; set; }
        public int TotalCount { get; }
        public IRange Range { get; }
    }
}
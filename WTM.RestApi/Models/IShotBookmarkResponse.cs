using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotBookmarkResponse : IResponse, IPaginableResult
    {
        IEnumerable<IShotSummary> Items { get; set; }
    }
}
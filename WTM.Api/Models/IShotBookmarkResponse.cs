using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IShotBookmarkResponse : IResponse, IPaginableResult
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
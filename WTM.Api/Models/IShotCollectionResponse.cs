using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IShotCollectionResponse : IResponse, IPaginableResult
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
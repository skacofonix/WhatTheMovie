using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotCollectionResponse : IResponse, IPaginableResult
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
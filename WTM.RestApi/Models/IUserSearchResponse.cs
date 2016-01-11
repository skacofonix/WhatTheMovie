using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IUserSearchResponse : IResponse, IPaginableResult
    {
        IEnumerable<IUserSearchSummary> Items { get; }
    }
}
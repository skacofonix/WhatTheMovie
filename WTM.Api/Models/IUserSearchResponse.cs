using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IUserSearchResponse : IResponse, IPaginableResult
    {
        IEnumerable<IUserSummary> Items { get; }
    }
}
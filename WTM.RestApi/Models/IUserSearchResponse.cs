using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IUserSearchResponse : IResponse, IPaginableResult
    {
        List<IUserSearchSummary> UserSearchSummaries { get; }
    }
}
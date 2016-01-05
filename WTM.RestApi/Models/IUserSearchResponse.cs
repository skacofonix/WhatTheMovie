using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IUserSearchResponse : IResponse, ISearchResult
    {
        List<IUserSearchSummary> UserSearchSummaries { get; }
    }
}
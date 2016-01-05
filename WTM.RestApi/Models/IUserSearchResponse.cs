using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IUserSearchResponse : ISearchResult
    {
        List<IUserSearchSummary> UserSearchSummaries { get; }
    }
}
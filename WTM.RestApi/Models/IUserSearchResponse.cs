using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IUserSearchResponse
    {
        // TODO : Add metadata navigation

        List<IUserSearchSummary> UserSearchSummaries { get; }
    }
}
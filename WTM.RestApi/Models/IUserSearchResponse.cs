using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IUserSearchResponse
    {
        // TODO : Add metadata navigation

        int TotalCount { get; set; }

        IRange Range { get; set; }

        List<IUserSearchSummary> UserSearchSummaries { get; }
    }
}
using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class UserSearchResponse : IUserSearchResponse
    {
        public List<IUserSearchSummary> UserSearchSummaries { get; set; }
    }
}
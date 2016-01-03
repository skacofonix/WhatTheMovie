using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class UserSearchResponse : IUserSearchResponse
    {
        public int TotalCount { get; set; }
        public IRange Range { get; set; }
        public List<IUserSearchSummary> UserSearchSummaries { get; set; }
    }
}
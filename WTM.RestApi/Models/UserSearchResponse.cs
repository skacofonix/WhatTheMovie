using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    internal class UserSearchResponse : IUserSearchResponse
    {
        public UserSearchResponse(IEnumerable<UserSummary> userSummaryList, IRange range, int totalCount)
        {
            this.Range = range;
            this.TotalCount = totalCount;

            var userSearchSummary = new List<IUserSearchSummary>();

            foreach (var userSummary in userSummaryList)
            {
                var userSummaryAdaptee = new UserSummaryAdapter(userSummary);
                userSearchSummary.Add(userSummaryAdaptee);
            }

            UserSearchSummaries = userSearchSummary;
        }

        public int TotalCount { get; set; }
        public IRange Range { get; set; }
        public List<IUserSearchSummary> UserSearchSummaries { get; }
    }
}
using System.Collections.Generic;
using WTM.Crawler.Domain;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    internal class UserSearchResponseAdapter : IUserSearchResponse
    {
        public UserSearchResponseAdapter(IEnumerable<UserSummary> userSummaryList, IRange range, int totalCount)
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
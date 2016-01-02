using System.Collections.Generic;
using WTM.Crawler.Domain;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    internal class UserSearchResponseAdapter : IUserSearchResponse
    {
        public UserSearchResponseAdapter(IEnumerable<UserSummary> userSummaryList)
        {
            var userSearchSummary = new List<IUserSearchSummary>();

            foreach (var userSummary in userSummaryList)
            {
                var userSummaryAdaptee = new UserSummaryAdapter(userSummary);
                userSearchSummary.Add(userSummaryAdaptee);
            }

            UserSearchSummaries = userSearchSummary;
        }

        public List<IUserSearchSummary> UserSearchSummaries { get; }
    }
}
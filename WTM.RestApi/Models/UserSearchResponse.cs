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
                var userSummaryAdaptee = new UserSearchSummary(userSummary);
                userSearchSummary.Add(userSummaryAdaptee);
            }

            Items = userSearchSummary;
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => Items.Count;
        public IRange Range { get; private set; }
        public List<IUserSearchSummary> Items { get; private set; }
    }
}
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    internal class UserSearchResponse : IUserSearchResponse
    {
        public UserSearchResponse(IEnumerable<UserSummary> crawlerUserSummaries, IRange displayRange, int totalCount)
        {
            this.DisplayRange = displayRange;   
            this.TotalCount = totalCount;
            Items = crawlerUserSummaries.Select(userSummary => new UserSearchSummary(userSummary)).Cast<IUserSearchSummary>().ToList();
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => Items.Count();
        public IRange DisplayRange { get; private set; }
        public IEnumerable<IUserSearchSummary> Items { get; private set; }
    }
}
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    internal class UserSearchResponse : IUserSearchResponse
    {
        public UserSearchResponse(IEnumerable<Crawler.Domain.UserSummary> crawlerUserSummaries, int startIndex, int totalCount)
        {
            this.TotalCount = totalCount;
            Items = crawlerUserSummaries.Select(userSummary => new UserSummary(userSummary)).Cast<IUserSummary>().ToList();
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => Items.Count();
        public int DisplayMin { get; private set; }
        public int DisplayMax => this.DisplayMin + this.DisplayCount;
        public IEnumerable<IUserSummary> Items { get; private set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;
using WTM.RestApi.Controllers.Models;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class UserService : IUserService
    {
        private readonly WTM.Crawler.Services.IUserService crawlerUserService;

        public UserService(Crawler.Services.IUserService crawlerUserService)
        {
            this.crawlerUserService = crawlerUserService;
        }

        public string Login(string username, string password)
        {
            return this.crawlerUserService.Login(username, password);
        }

        public void Logout(string token)
        {
            this.crawlerUserService.Logout();
        }

        public User GetUserByName(string username)
        {
            return this.crawlerUserService.GetByUsername(username);
        }

        public IUserSearchResponse Search(UserSearchRequest filter)
        {
            const int pageSize = 30;

            var start = filter.Start.GetValueOrDefault(1);
            var limit = filter.Limit.GetValueOrDefault(pageSize);
            var pageStart = (int)Math.Ceiling(start / (double)pageSize);
            var pageEnd = (int)Math.Ceiling((start + limit) / (double)pageSize);

            var userSummaryList = new List<UserSummary>();

            var pageIndex = pageStart;
            var continueLoop = true;
            UserSearchResult userSearchResult = null;

            var rangeMax = start + limit;
            do
            {
                userSearchResult = this.crawlerUserService.Search(filter.Filter, pageIndex);
                userSummaryList.AddRange(userSearchResult.UserSummaries);

                pageIndex++;

                var realPageEnd = (int) Math.Ceiling(userSearchResult.Count/(double)pageSize);
                if (pageIndex > realPageEnd)
                {
                    continueLoop = false;
                    rangeMax = userSearchResult.RangeItem.MaxValue;
                }

                if (pageIndex > pageEnd)
                {
                    continueLoop = false;
                }
            } while (continueLoop);

            var skipWithOffset = start - (pageStart-1) * pageSize - 1;
            var userSummaryListFiltered = userSummaryList.Skip(skipWithOffset).Take(limit).ToList();

            if (userSummaryListFiltered.Count == 0)
            {
                start = 0;
            }

            var range = new Models.Range(start, rangeMax);

            var result = new UserSearchResponseAdapter(userSummaryListFiltered, range, userSearchResult.Count);

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;
using WTM.RestApi.Controllers;
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

            for (var pageIndex = pageStart; pageIndex <= pageEnd; pageIndex++)
            {
                var userSummaries = this.crawlerUserService.Search(filter.Filter, pageIndex);
                userSummaryList.AddRange(userSummaries);

                // TODO : Store and check the number of result page !
            }

            var skipWithOffset = start - (pageStart-1) * pageSize - 1;
            var userSummaryListFiltered = userSummaryList.Skip(skipWithOffset).Take(limit);
            var result = new UserSearchResponseAdapter(userSummaryListFiltered);

            return result;
        }
    }
}
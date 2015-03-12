﻿using System.Collections.Generic;
using System.Linq;
using WTM.Core.Services;
using WTM.Crawler.Parsers;
using WTM.Domain;

namespace WTM.Crawler.Services
{
    public class UserService : IUserService
    {
        private readonly UserParser userParser;
        private readonly SearchUserParser userSearcher;

        public UserService(IWebClient webClient, IHtmlParser htmlParser)
        {
            userParser= new UserParser(webClient, htmlParser);
            userSearcher = new SearchUserParser(webClient, htmlParser);
        }

        public User GetByUsername(string username)
        {
            return userParser.GetByUsername(username);
        }

        public IEnumerable<UserSummary> Search(string username, int? page = null)
        {
            var result = userSearcher.Search(username, page);
            return result.Items.Cast<UserSummary>().ToList();
        }
    }
}
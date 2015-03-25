using System.Collections.Generic;
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
        private readonly AuthenticateService authenticateService;

        public UserService(IWebClient webClient, IHtmlParser htmlParser)
        {
            userParser = new UserParser(webClient, htmlParser);
            userSearcher = new SearchUserParser(webClient, htmlParser);
            authenticateService = new AuthenticateService(webClient, htmlParser);
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

        public User Login(string username, string password)
        {
            var token = authenticateService.Login(username, password);
            if (token == null)
                return null;

            var user = GetByUsername(username);
            user.Token = token;

            return user;
        }

        public void Logout()
        { }
    }
}
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

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

        public SearchResultCollection Search(string search, int? page = null)
        {
            return userSearcher.Search(search, page);
        }

        public string Login(string username, string password)
        {
            return authenticateService.Login(username, password);
        }

        public void Logout()
        { }
    }
}
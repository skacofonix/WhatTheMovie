using System.Collections.Generic;
using System.Linq;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.Interfaces;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Parsers;

namespace WTM.WebsiteClient.Services
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

        public IUser GetUser(string username)
        {
            return userParser.Parse(username);
        }

        public IEnumerable<IUserSummary> Search(string username, int? page = null)
        {
            var result = userSearcher.Search(username, page);
            return result.Items.Cast<IUserSummary>().ToList();
        }
    }
}
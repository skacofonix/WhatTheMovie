using System.Collections.Generic;
using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IUserService
    {
        User Get(string username);

        UserSummary GetSummary(string username);

        UserSearchResult Search(string search, int? page = null);

        string Login(string username, string password);

        void Logout();
    }
}
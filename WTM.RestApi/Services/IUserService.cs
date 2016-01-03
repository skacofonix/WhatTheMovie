using WTM.Crawler.Domain;
using WTM.RestApi.Controllers.Models;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IUserService
    {
        string Login(string username, string password);

        void Logout(string token);

        User GetUserByName(string username);

        IUserSearchResponse Search(UserSearchRequest filter);
    }
}
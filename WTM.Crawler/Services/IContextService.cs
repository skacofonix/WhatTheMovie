using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    interface IContextService
    {
        User Login(string username, string password);

        bool Logout();
    }
}
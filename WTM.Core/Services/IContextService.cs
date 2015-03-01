using WTM.Domain;

namespace WTM.Core.Services
{
    interface IContextService
    {
        User Login(string username, string password);

        bool Logout();
    }
}
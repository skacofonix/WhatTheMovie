using WTM.Domain;

namespace WTM.Core.Services
{
    interface IContextService
    {
        IUser Login(string username, string password);

        bool Logout();
    }
}
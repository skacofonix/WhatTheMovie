using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Core.Services
{
    interface IContextService
    {
        IUser Login(string username, string password);

        bool Logout();
    }
}
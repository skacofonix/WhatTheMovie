using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IUserService
    {
        IUser GetUser(string username);
    }
}
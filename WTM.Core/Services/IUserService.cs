using WTM.Domain;

namespace WTM.Api.Core.Services
{
    public interface IUserService
    {
        IUser GetUser(string username);
    }
}
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IUserService
    {
        IUserResponse Get(string username);

        IUserLoginResponse Login(UserLoginRequest request);

        IUserLogoutResponse Logout(UserLogoutRequest request);

        IUserSearchResponse Search(UserSearchRequest request);

        IUserSummary GetUserSummaryByToken(string token);
    }
}
namespace WTM.RestApi.Services
{
    interface IUserService
    {
        string Login(string username, string password);

        void Logout(string token);
    }
}
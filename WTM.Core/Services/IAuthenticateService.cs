namespace WTM.Crawler.Services
{
    public interface IAuthenticateService
    {
        string Login(string login, string password);
        void Logout();
    }
}
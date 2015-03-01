namespace WTM.Crawler.Services
{
    public interface IAuthenticateService
    {
        bool Login(string login, string password);
        void Logout();
    }
}
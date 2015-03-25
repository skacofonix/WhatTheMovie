namespace WTM.Crawler.Services
{
    public interface IAuthenticateService
    {
        string Login(string username, string password);
        void Logout();
    }
}
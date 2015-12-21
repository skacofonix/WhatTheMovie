using WTM.Crawler.Domain;

namespace WTM.RestApi.Services
{
    public class UserService : IUserService
    {
        private readonly WTM.Crawler.Services.IUserService crawlerUserService;

        public UserService(Crawler.Services.IUserService crawlerUserService)
        {
            this.crawlerUserService = crawlerUserService;
        }

        public string Login(string username, string password)
        {
            return this.crawlerUserService.Login(username, password);
        }

        public void Logout(string token)
        {
            this.crawlerUserService.Logout();
        }

        public User GetUserByName(string username)
        {
            return this.crawlerUserService.GetByUsername(username);
        }
    }
}
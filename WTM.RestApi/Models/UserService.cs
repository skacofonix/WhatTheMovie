using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.RestApi.Models
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
    }
}

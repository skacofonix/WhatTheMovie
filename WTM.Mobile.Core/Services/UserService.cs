using System.Collections.Generic;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IContext context;
        private readonly IUserService userService;

        public UserService(IContext context)
        {
            this.context = context;
            var settings = new SettingsAzure();
            var settingsAdapter = new ApiClientSettingsAdapter(settings);
            userService = new Api.Client.Services.UserService(settingsAdapter);
        }

        public User GetByUsername(string username)
        {
            return userService.GetByUsername(username);
        }

        public IEnumerable<UserSummary> Search(string username, int? page = null)
        {
            return userService.Search(username, page);
        }

        public User Login(string username, string password)
        {
            var user = userService.Login(username, password);
            context.CurrentUser = user;
            return user;
        }

        public void Logout()
        {
            userService.Logout();
            context.CurrentUser = null;
        }
    }
}
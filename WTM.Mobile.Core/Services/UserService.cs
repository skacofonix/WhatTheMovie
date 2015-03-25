using System.Collections.Generic;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService userService;

        public UserService()
        {
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
    }
}
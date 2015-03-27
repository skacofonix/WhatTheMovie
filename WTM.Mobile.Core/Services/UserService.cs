using System;
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

        public IEnumerable<UserSummary> Search(string search, int? page = null)
        {
            return userService.Search(search, page);
        }

        public string Login(string username, string password)
        {
            string token = null;

            try
            {
                token = userService.Login(username, password);

            }
            catch (Exception ex)
            {
                // ToDo log
            }

            return token;
        }

        public void Logout()
        {
            userService.Logout();
            context.ResetUserContext();
        }
    }
}
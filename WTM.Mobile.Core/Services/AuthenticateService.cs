using WTM.Crawler.Services;

namespace WTM.Mobile.Core.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateService authenticateService;

        public AuthenticateService()
        {
            var settings = new SettingsAzure();
            var settingsAdapter = new ApiClientSettingsAdapter(settings);
            authenticateService = new Api.Client.Services.AuthenticationService(settingsAdapter);
        }

        public string Login(string username, string password)
        {
            return authenticateService.Login(username, password);
        }

        public void Logout()
        { }
    }
}
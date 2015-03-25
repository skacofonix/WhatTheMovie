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

        public string Login(string login, string password)
        {
            return authenticateService.Login(login, password);
        }

        public void Logout()
        { }
    }
}
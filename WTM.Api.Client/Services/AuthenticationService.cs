using System;
using System.Net;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Crawler.Services;

namespace WTM.Api.Client.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly Uri baseUri;
        private readonly HttpClient httpClient;

        public AuthenticationService(ISettings settings)
        {
            baseUri = new Uri(settings.Host, "account/");
            httpClient = new HttpClient();
        }

        public string Login(string login, string password)
        {
            var uri = new Uri(baseUri, string.Format("login={0}&password={1}",
                WebUtility.UrlEncode(login),
                WebUtility.UrlEncode(password)));

            return  httpClient.GetStringSync(uri);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}

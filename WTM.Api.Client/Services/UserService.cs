using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Client.Services
{
    public class UserService : IUserService
    {
        private readonly Uri baseUri;
        private readonly HttpClient httpClient;

        public UserService(ISettings settings)
        {
            baseUri = new Uri(settings.Host, "user/");
            httpClient = new HttpClient();
        }

        public User GetByUsername(string username)
        {
            User user = null;

            var uri = new Uri(baseUri, WebUtility.UrlEncode(username));

            user = httpClient.GetObjectSync<User>(uri);

            return user;
        }

        public IEnumerable<UserSummary> Search(string username, int? page = null)
        {
            throw new NotImplementedException();
        }

        public User Login(string username, string password)
        {
            User user = null;

            var uri = new Uri(baseUri, string.Format("Login?username={0}&password={1}",
                WebUtility.UrlEncode(username),
                WebUtility.UrlEncode(password)));

            user = httpClient.GetObjectSync<User>(uri);

            return user;
        }

        public void Logout()
        { }
    }
}
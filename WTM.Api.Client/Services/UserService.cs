using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Common.Helpers;
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

        public IEnumerable<UserSummary> Search(string search, int? page = null)
        {
            List<UserSummary> userCollection = null;

            var uri = new Uri(baseUri, string.Format("?search={0}&page={1}", WebUtility.UrlEncode(search), page));

            // Ouch! how to parse Lis<User>, maybe i should use a specific UserCollection to encapsulate this list
            userCollection = httpClient.GetObjectSync<List<UserSummary>>(uri);

            return userCollection;
        }

        public string Login(string username, string password)
        {
            string token = null;

            var requestBuilder = new HttpRequestBuilder("Login");
            requestBuilder.AddParameter("username", WebUtility.UrlEncode(username));
            requestBuilder.AddParameter("password", WebUtility.UrlEncode(password));

            var uri = new Uri(baseUri, requestBuilder.ToString());

            var loginResponse = httpClient.GetObjectSync<LoginResponse>(uri);

            if (loginResponse.Token != null)
                token = loginResponse.Token;

            return token;
        }

        public void Logout()
        { }
    }
}
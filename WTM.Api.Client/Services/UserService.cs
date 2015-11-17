using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Common.Helpers;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.OldSchool;

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

            var userResponse = httpClient.GetObjectSync<UserResponse>(uri);

            if (!userResponse.HasError)
                user = userResponse.User;

            return user;
        }

        public IEnumerable<UserSummary> Search(string search, int? page = null)
        {
            List<UserSummary> userCollection = null;

            var requestBuilder = new HttpRequestBuilder();
            requestBuilder.AddParameter("search", WebUtility.UrlEncode(search));
            if(page.HasValue)
                requestBuilder.AddParameter("page", page.GetValueOrDefault(1).ToString());

            var uri = new Uri(baseUri, requestBuilder.ToString());

            var searchResponse = httpClient.GetObjectSync<UserSearchResponse>(uri);

            if (!searchResponse.HasError)
                userCollection = searchResponse.UserSummaries;

            return userCollection;
        }

        public string Login(string username, string password)
        {
            string token = null;

            var requestBuilder = new HttpRequestBuilder("Login");
            requestBuilder.AddParameter("username", WebUtility.UrlEncode(username));
            requestBuilder.AddParameter("password", WebUtility.UrlEncode(password));

            var uri = new Uri(baseUri, requestBuilder.ToString());

            var loginResponse = httpClient.GetObjectSync<UserLoginResponse>(uri);

            if (!loginResponse.HasError && !string.IsNullOrEmpty(loginResponse.Token))
                token = loginResponse.Token;

            return token;
        }

        public void Logout()
        { }
    }
}
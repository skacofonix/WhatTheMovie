﻿using System;
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

        public User GetUser(string username)
        {
            User user = null;

            var uri = new Uri(baseUri, WebUtility.UrlEncode(username));

            var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
            {
                user = result.Result.Deserialize<User>();
            });

            task.Wait();

            return user;
        }

        public IEnumerable<UserSummary> Search(string username, int? page = null)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Test
{
    public class UserServiceFake : IUserService
    {
        public User GetByUsername(string username)
        {
            return new User
            {
                Name = username
            };
        }

        public IEnumerable<UserSummary> Search(string search, int? page = null)
        {
            return new List<UserSummary>
            {
                new UserSummary(),
                new UserSummary(),
                new UserSummary(),
                new UserSummary(),
                new UserSummary(),
            };
        }

        public string Login(string username, string password)
        {
            return Guid.NewGuid().ToString();
        }

        public void Logout()
        { }
    }
}
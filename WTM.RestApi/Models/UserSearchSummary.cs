using System;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    internal class UserSearchSummary : IUserSearchSummary
    {
        private readonly UserSummary userSummary;

        public UserSearchSummary(UserSummary userSummary)
        {
            this.userSummary = userSummary;
        }

        public string Username => userSummary.Username;

        public string Rank => userSummary.Rank;

        public Uri AvatarUrl => userSummary.AvatarUrl;

        public Uri ProfilUrl => userSummary.ProfilUrl;
    }
}
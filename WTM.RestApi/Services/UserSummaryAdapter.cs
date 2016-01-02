using System;
using WTM.Crawler.Domain;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    internal class UserSummaryAdapter : IUserSearchSummary
    {
        private readonly UserSummary userSummary;

        public UserSummaryAdapter(UserSummary userSummary)
        {
            this.userSummary = userSummary;
        }

        public string Username => userSummary.Username;

        public string Rank => userSummary.Rank;

        public Uri Avatar => userSummary.Avatar;
    }
}
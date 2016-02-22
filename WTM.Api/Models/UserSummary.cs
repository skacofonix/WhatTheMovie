using System;
using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    internal class UserSummary : IUserSummary
    {
        private readonly Crawler.Domain.UserSummary userSummary;

        public UserSummary(Crawler.Domain.UserSummary userSummary)
        {
            this.userSummary = userSummary;
        }

        [Required]
        public string Username => userSummary.Username;

        public string Rank => userSummary.Rank;

        public Uri AvatarUrl => userSummary.AvatarUrl;

        public Uri ProfilUrl => userSummary.ProfilUrl;
    }
}
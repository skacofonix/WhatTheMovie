using System;

namespace WTM.RestApi.Models
{
    public class UserSearchSummary : IUserSearchSummary
    {
        public string Username { get; set; }
        public string Rank { get; set; }
        public Uri Avatar { get; set; }
    }
}
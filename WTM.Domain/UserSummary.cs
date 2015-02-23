using System;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class UserSummary : IUserSummary
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }
        
        public string Username { get; set; }
        
        public string Rank { get; set; }
        
        public string Status { get; set; }
        
        public string Country { get; set; }
        
        public Uri Avatar { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class UserSummary : IUserSummary
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        public string Username { get; set; }
        
        public string Rank { get; set; }
        
        public string Status { get; set; }
        
        public string Country { get; set; }
        
        public Uri Avatar { get; set; }
    }
}
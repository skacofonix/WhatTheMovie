using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class UserSummaryCollection : IWebsiteEntity
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }
        
        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }
        
        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        [DataMember]
        public IList<UserSummary> Users { get; set; }
    }
}

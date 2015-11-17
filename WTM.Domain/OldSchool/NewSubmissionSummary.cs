using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.OldSchool.Interfaces;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class NewSubmissionSummary : IShotSummary
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }
        
        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }
        
        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        [DataMember]
        public int ShotId { get; set; }
        
        [DataMember]
        public string ImageUrl { get; set; }
        
        [DataMember]
        public ShotUserStatus UserStatus { get; set; }
        
        [DataMember]
        public Rate Rate { get; private set; }
        
        [DataMember]
        public int TimeRemaining { get; private set; }
    }
}
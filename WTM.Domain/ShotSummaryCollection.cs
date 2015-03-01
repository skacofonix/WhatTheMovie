using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class ShotSummaryCollection : IWebsiteEntity
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }
        
        public DateTime? Date { get; set; }
        
        public IList<ShotSummary> Shots { get; set; }
        
        public ShotType? ShotType { get; set; }
    }
}

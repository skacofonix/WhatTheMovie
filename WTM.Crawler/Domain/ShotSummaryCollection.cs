using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class ShotSummaryCollection : IWebsiteEntity
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        public Uri Uri { get; set; }

        public string ConnectedUsername { get; set; }

        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public IList<IShotSummary> Shots { get; set; }

        [DataMember]
        public ShotType? ShotType { get; set; }

        public UserSummary UserSummary { get; set; }
    }
}
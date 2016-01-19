using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class MovieSummary : IWebsiteEntity
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
        public string MovieId { get; private set; }

        [DataMember]
        public string OriginalTitle { get; private set; }

        [DataMember]
        public int? Year { get; private set; }

        [DataMember]
        public Uri Image { get; private set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class SearchResultCollection : IWebsiteEntity, ISearchResultCollection
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        public string ConnectedUsername { get; set; }

        public IList Items { get; set; }
        public int Count { get; set; }
        public Range RangeItem { get; set; }
    }
}
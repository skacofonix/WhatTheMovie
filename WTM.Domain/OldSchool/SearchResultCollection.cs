using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.OldSchool.Interfaces;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class SearchResultCollection : IWebsiteEntity
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        public IList Items { get; set; }
        public int? Total { get; set; }
        public Range Range { get; set; }
    }
}
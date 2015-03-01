using System;
using System.Collections;
using System.Collections.Generic;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class SearchResultCollection : IWebsiteEntity
    {
        public DateTime ParseDateTime { get; set; }

        public TimeSpan ParseDuration { get; set; }

        public IList<ParseInfo> ParseInfos { get; set; }

        public IList Items { get; set; }
        public int? Total { get; set; }
        public Range Range { get; set; }

        public SearchResultCollection()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}
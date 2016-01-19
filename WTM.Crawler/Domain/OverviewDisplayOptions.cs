using System;
using System.Collections.Generic;

namespace WTM.Crawler.Domain
{
    public class OverviewDisplayOptions : IWebsiteEntity
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }

        public IList<ParseInfo> ParseInfos { get; set; }
        public Uri Uri { get; set; }
        public string ConnectedUsername { get; set; }

        public bool ShowSolved { get; set; }
        
        public bool ShowUnsolved { get; set; }
        
        public bool ShowPosted { get; set; }
    }
}
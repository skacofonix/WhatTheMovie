using System;
using System.Collections.Generic;
using WTM.Domain.OldSchool.Interfaces;

namespace WTM.Domain.OldSchool
{
    public class OverviewDisplayOptions : IWebsiteEntity
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }

        public IList<ParseInfo> ParseInfos { get; set; }

        public bool ShowSolved { get; set; }
        
        public bool ShowUnsolved { get; set; }
        
        public bool ShowPosted { get; set; }
    }
}
using System;
using System.Collections.Generic;
using WTM.Domain.OldSchool.Interfaces;

namespace WTM.Domain.OldSchool
{
    public class MovieSummaryCollection : IWebsiteEntity
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }

        public IList<ParseInfo> ParseInfos { get; set; }
       
        public DateTime? Date { get; set; }
        
        public IList<MovieSummary> Movies { get; set; }
    }
}
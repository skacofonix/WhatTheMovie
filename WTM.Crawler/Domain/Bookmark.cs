using System;
using System.Collections.Generic;

namespace WTM.Crawler.Domain
{
    public class Bookmark : IWebsiteEntity
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }
        
        public IList<ParseInfo> ParseInfos { get; set; }
        public string ConnectedUsername { get; set; }

        public string ShotUrl { get; set; }
        
        public int? ShotId { get; set; }
        
        public string ImageUrl { get; set; }
        
        public int? NbDaysLeft { get; set; }
        
        public bool SolutionAvailable { get; set; }
    }
}
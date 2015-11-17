using System;
using System.Collections.Generic;
using WTM.Domain.OldSchool.Interfaces;

namespace WTM.Domain.OldSchool
{
    public class BookmarkCollection : IWebsiteEntity
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }
        
        public IList<ParseInfo> ParseInfos { get; set; }
        
        public List<Bookmark> Bookmarks { get; set; }
        
        public int NumberOfPage { get; set; }
    }
}
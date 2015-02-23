﻿using System;
using System.Collections.Generic;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class BookmarkCollection : IBookmarkCollection
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }
        
        public IList<ParseInfo> ParseInfos { get; set; }
        
        public List<Bookmark> Bookmarks { get; set; }
        
        public int NumberOfPage { get; set; }
    }
}
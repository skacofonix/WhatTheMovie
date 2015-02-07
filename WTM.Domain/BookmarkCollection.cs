﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class BookmarkCollection : IBookmarkCollection
    {
        public DateTime ParseDateTime { get; set; }
        public TimeSpan ParseDuration { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public int NumberOfPage { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class BookmarkCollection : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        public List<Bookmark> Bookmarks { get; set; }

        public BookmarkCollection()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}
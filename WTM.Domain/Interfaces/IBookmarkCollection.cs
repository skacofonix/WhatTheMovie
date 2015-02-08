using System;
using System.Collections.Generic;
using System.Text;

namespace WTM.Domain.Interfaces
{
    public interface IBookmarkCollection : IWebsiteEntity
    {
        List<Bookmark> Bookmarks { get; set; }

        int NumberOfPage { get; set; }
    }
}

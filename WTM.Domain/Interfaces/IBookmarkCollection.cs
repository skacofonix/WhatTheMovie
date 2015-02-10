using System.Collections.Generic;

namespace WTM.Domain.Interfaces
{
    public interface IBookmarkCollection : IWebsiteEntity
    {
        List<Bookmark> Bookmarks { get; set; }

        int NumberOfPage { get; set; }
    }
}

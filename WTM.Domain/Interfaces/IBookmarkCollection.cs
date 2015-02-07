using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Domain.Interfaces
{
    public interface IBookmarkCollection : IWebsiteEntity
    {
        List<Bookmark> Bookmarks { get; set; }

        int NumberOfPage { get; set; }
    }
}

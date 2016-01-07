using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class BookmarkService
    {
        private readonly BookmarksParser parser;

        public BookmarkService(BookmarksParser parser)
        {
            this.parser = parser;
        }

        public BookmarkCollection GetBookmark(string token, int? page)
        {
            return parser.GetBookmarksByPage(page ?? 1);
        }

        public bool Add(int id, string token)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, string token)
        {
            throw new NotImplementedException();
        }
    }
}

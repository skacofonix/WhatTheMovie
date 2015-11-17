
using WTM.Domain;

namespace WTM.RestApi
{
    internal class BookmarkAdapter : IShotOverview
    {
        private WTM.Crawler.Domain.Bookmark bookmark;

        public BookmarkAdapter(WTM.Crawler.Domain.Bookmark bookmark)
        {
            this.bookmark = bookmark;
        }

        public int Id
        {
            get
            {
                return bookmark.ShotId.GetValueOrDefault(0);
            }
        }
    }
}
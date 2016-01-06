
namespace WTM.Domain
{
    internal class BookmarkAdapter : IBookmark
    {
        private IBookmark bookmark;

        public BookmarkAdapter(IBookmark bookmark)
        {
            this.bookmark = bookmark;
        }

        public int Id
        {
            get
            {
                return bookmark.Id;
            }
        }
    }
}
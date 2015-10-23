using System;
using WTM.Crawler.Domain;
using WTM.RestApi.Models;

namespace WTM.RestApi.Models
{
    internal class BookmarkAdapter : IShotOverview
    {
        private Bookmark bookmark;

        public BookmarkAdapter(Bookmark bookmark)
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
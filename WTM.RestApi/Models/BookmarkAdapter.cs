using System;

namespace WTM.RestApi.Models
{
    internal class BookmarkAdapter : IShotSummary
    {
        private readonly WTM.Crawler.Domain.Bookmark bookmark;

        public BookmarkAdapter(WTM.Crawler.Domain.Bookmark bookmark)
        {
            this.bookmark = bookmark;
        }
        
        public int ShotId => bookmark.ShotId.Value;
        public Uri ImageUri => new Uri(bookmark.ImageUrl);
        public ShotUserStatus UserStatus { get; }
    }
}
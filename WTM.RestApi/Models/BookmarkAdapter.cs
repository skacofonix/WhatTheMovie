using System;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    internal class BookmarkAdapter : IShotSummary
    {
        private readonly WTM.Crawler.Domain.Bookmark bookmark;

        public BookmarkAdapter(WTM.Crawler.Domain.Bookmark bookmark)
        {
            this.bookmark = bookmark;
        }
        
        public int Id => bookmark.ShotId.Value;

        [Required]
        public string Thumb => $"/api/shots/{bookmark.ShotId}/thumb";

        public ShotUserStatus Status { get; }
    }
}
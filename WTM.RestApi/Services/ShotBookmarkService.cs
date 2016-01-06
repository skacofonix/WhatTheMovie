using System;
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Services
{
    public class ShotBookmarkService : IShotBookmarkService
    {
        const int limitMax = 100;

        private readonly Crawler.Services.BookmarkService bookmarkService;

        public ShotBookmarkService(Crawler.Services.BookmarkService bookmarkService)
        {
            this.bookmarkService = bookmarkService;
        }

        public ShotBookmarkResponse Get(string token, int? start, int? limit)
        {
            var bookmarks = new List<Bookmark>();

            var firstPage = this.bookmarkService.GetBookmark(token, null);

            if (firstPage.NumberOfPage > 1)
            {
                var nbItemPerPage = firstPage.Bookmarks.Count;
                var nbPage = firstPage.NumberOfPage;

                var startIndex = start ?? 1;
                var endIndex = limit ?? limitMax;

                var startPage = Math.Min(1, startIndex / nbItemPerPage);
                var endPage = Math.Max(nbPage, (startIndex + endIndex) / nbItemPerPage);

                for (var indexPage = startPage; indexPage <= endPage; indexPage++)
                {
                    var bookmarkPage = this.bookmarkService.GetBookmark(token, indexPage);
                    bookmarks.AddRange(bookmarkPage.Bookmarks);
                }
            }
            else
            {
                bookmarks.AddRange(firstPage.Bookmarks);
            }

            int skip = start ?? 1;
            int take = limit ?? limitMax;

            var shotOverviewResponses = bookmarks.Select(s => new BookmarkAdapter(s)).Cast<WTM.RestApi.Models.ShotSummary>();

            return new ShotBookmarkResponse(shotOverviewResponses);
        }

        public ShotBookmarkAddResponse Add(int id, string token)
        {
            var success = this.bookmarkService.Add(id, token);
            return new ShotBookmarkAddResponse(success);
        }

        public ShotBookmarkDeleteResponse Delete(int id, string token)
        {
            var success = this.bookmarkService.Delete(id, token);
            return new ShotBookmarkDeleteResponse(success);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotBookmarkService : IShotBookmarkService
    {
        const int LimitMax = 100;

        private readonly Crawler.Services.BookmarkService bookmarkService;

        public ShotBookmarkService(Crawler.Services.BookmarkService bookmarkService)
        {
            this.bookmarkService = bookmarkService;
        }

        public ShotBookmarkResponse Get(BookmarksGetRequest request)
        {
            var start = request.Start.GetValueOrDefault(1);

            var bookmarks = new List<Bookmark>();

            var firstPage = this.bookmarkService.GetBookmark(request.Token, null);

            if (firstPage.NumberOfPage > 1)
            {
                var nbItemPerPage = firstPage.Bookmarks.Count;
                var nbPage = firstPage.NumberOfPage;

                var startIndex = request.Start.GetValueOrDefault(1);
                var endIndex = request.Limit.GetValueOrDefault(LimitMax);

                var startPage = Math.Min(1, startIndex / nbItemPerPage);
                var endPage = Math.Max(nbPage, (startIndex + endIndex) / nbItemPerPage);

                for (var indexPage = startPage; indexPage <= endPage; indexPage++)
                {
                    var bookmarkPage = this.bookmarkService.GetBookmark(request.Token, indexPage);
                    bookmarks.AddRange(bookmarkPage.Bookmarks);
                }
            }
            else
            {
                bookmarks.AddRange(firstPage.Bookmarks);
            }

            var shotOverviewResponses = bookmarks.Select(s => new BookmarkAdapter(s)).Cast<Models.ShotSummary>();

            return new ShotBookmarkResponse(shotOverviewResponses, start, 0);
        }

        public ShotBookmarkAddResponse Add(int id, BookmarksAddRequest request)
        {
            var success = this.bookmarkService.Add(id, request.Token);
            return new ShotBookmarkAddResponse(success);
        }

        public ShotBookmarkDeleteResponse Delete(int id, BookmarksDeleteRequest request)
        {
            var success = this.bookmarkService.Delete(id, request.Token);
            return new ShotBookmarkDeleteResponse(success);
        }
    }
}
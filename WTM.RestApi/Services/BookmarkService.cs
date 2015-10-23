﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Crawler.Domain;
using WTM.RestApi.Models;
using WTM.RestApi.Models.Response;

namespace WTM.RestApi.Services
{
    public class BookmarkService : IShotBookmarkService
    {
        const int limitMax = 100;

        private readonly Crawler.Services.BookmarkService bookmarkService;

        public BookmarkService(Crawler.Services.BookmarkService bookmarkService)
        {
            this.bookmarkService = bookmarkService;
        }

        public bool Add(int id, string token)
        {
            return this.bookmarkService.Add(id, token);
        }

        public bool Delete(int id, string token)
        {
            return this.bookmarkService.Delete(id, token);
        }

        public IEnumerable<ShotOverviewResponse> GetBookmarks(string token, int? start, int? limit)
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

            var shotOverviewResponses = bookmarks.Select(s => new ShotOverviewResponse(new BookmarkAdapter(s)));

            return shotOverviewResponses;
        }
    }
}

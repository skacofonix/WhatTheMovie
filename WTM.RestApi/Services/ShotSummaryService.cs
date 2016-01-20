using System;
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;
using WTM.Crawler.Services;
using WTM.RestApi.Models;
using Range = WTM.RestApi.Models.Range;
using ShotSummary = WTM.RestApi.Models.ShotSummary;

namespace WTM.RestApi.Services
{
    public class ShotSummaryService : IShotSummaryService
    {
        private readonly Crawler.Services.IShotOverviewService shotOverviewService;
        private readonly Crawler.Services.IShotFeatureFilmsService shotFeatureFilmsService;
        private readonly Crawler.Services.IShotArchiveService shotArchiveService;
        private readonly Crawler.Services.IShotNewSubmissionsService shotNewSubmissionService;
        private readonly Crawler.Services.IUserService userService;
        private readonly IImageRepository imageRepository;
        private readonly IDateTimeService dateTimeService;
        const int limitMax = 100;
        const int nbDayFeatureFilms = 30;
        
        public ShotSummaryService(
            Crawler.Services.IShotOverviewService shotOverviewService,
            Crawler.Services.IShotFeatureFilmsService shotFeatureFilmsService,
            Crawler.Services.IShotArchiveService shotArchiveService,
            Crawler.Services.IShotNewSubmissionsService shotNewSubmissionService,
            Crawler.Services.IUserService userService,
            Crawler.Services.IImageRepository imageRepository,
            IDateTimeService dateTimeService)
        {
            this.shotOverviewService = shotOverviewService;
            this.shotFeatureFilmsService = shotFeatureFilmsService;
            this.shotArchiveService = shotArchiveService;
            this.shotNewSubmissionService = shotNewSubmissionService;
            this.userService = userService;
            this.imageRepository = imageRepository;
            this.dateTimeService = dateTimeService;
        }

        public IShotCollectionResponse Get(ShotsRequest request)
        {
            var date = request?.Date ?? this.dateTimeService.GetDateTime();

            var result = Get(date, request?.Start, request?.Limit, request?.Token);

            return result;
        }

        public IShotCollectionResponse GetArchives(ShotArchivesRequest request)
        {
            var maxDate = dateTimeService.GetDateTime().Date.AddDays(-nbDayFeatureFilms);
            var date = maxDate;

            if (request?.Date != null )
            {
                if (request.Date.Value >= maxDate)
                {
                    throw new ArgumentOutOfRangeException(nameof(request), $"Date must be before {maxDate}");
                }

                date = request.Date.Value;
            }

            return Get(date, request?.Start, request?.Limit, request?.Token);
        }

        public IShotCollectionResponse GetFeatureFilms(ShotFeatureFilmsRequest request)
        {
            var now = dateTimeService.GetDateTime().Date;
            var minDate = now.AddDays(-nbDayFeatureFilms);
            var date = now;

            if (request?.Date != null)
            {
                if (request.Date.Value < minDate)
                {
                    throw new ArgumentOutOfRangeException(nameof(request), $"Date must be after {minDate}");
                }

                date = request.Date.Value;
            }

            return Get(date, request?.Start, request?.Limit, request?.Token);
        }

        public IShotCollectionResponse GetNewSubmissions(ShotNewSubmissionsRequest request)
        {
            var date = dateTimeService.GetDateTime().Date;
            var shotSummaryCollection = this.shotNewSubmissionService.GetShots(request.Token);
            return Foo(shotSummaryCollection, date, request?.Start, request?.Limit, request?.Token);
        }

        public IShotSearchTagResponse Search(ShotSearchRequest request)
        {
            const int pageSize = 50;

            var start = request.Start.GetValueOrDefault(1);
            var limit = request.Limit.GetValueOrDefault(pageSize);
            var pageStart = (int)Math.Ceiling(start / (double)pageSize);
            var pageEnd = (int)Math.Ceiling((start + limit) / (double)pageSize);

            var userSummaryList = new List<WTM.Crawler.Domain.IShotSummary>();

            var totalCount = 0;
            var pageIndex = pageStart;
            var continueLoop = true;
            do
            {
                var shotSummaryCollection = this.shotOverviewService.Search(request.Tag, pageIndex);
                if (shotSummaryCollection != null)
                {
                    totalCount = shotSummaryCollection.Count;
                    if (shotSummaryCollection.ShotSummaries != null)
                    {
                        userSummaryList.AddRange(shotSummaryCollection.ShotSummaries);
                    }
                }

                pageIndex++;

                var realPageEnd = (int)Math.Ceiling(totalCount / (double)pageSize);
                if (pageIndex > realPageEnd)
                {
                    continueLoop = false;
                }

                if (pageIndex > pageEnd)
                {
                    continueLoop = false;
                }
            } while (continueLoop);

            var skipWithOffset = start - (pageStart - 1) * pageSize - 1;
            var shotSummaryListFiltered = userSummaryList.Skip(skipWithOffset).Take(limit).ToList();

            return new ShotSearchResponse(shotSummaryListFiltered, start, totalCount);
        }

        private IShotCollectionResponse Get(DateTime date, int? start, int? limit, string token = null)
        {
            var shotSummaryCollection = this.shotOverviewService.GetShotSummaryByDate(date, token);
            return Foo(shotSummaryCollection, date, start, limit, token);
        }

        private IShotCollectionResponse Foo(ShotSummaryCollection shotSummaryCollection, DateTime date, int? start, int? limit, string token = null)
        {
            IShotCollectionResponse result;
            if (shotSummaryCollection != null)
            {
                var skip = start ?? 0;
                var take = limit ?? limitMax;
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take).ToList();
                var startItem = start ?? 1;
                var totalCount = shotSummaryCollection.Shots.Count;
                result = new ShotCollectionResponse(date, startItem, totalCount, filteredShots.Select(x => new ShotSummary(x)));
            }
            else
            {
                result = new ShotCollectionResponse(date, 0, 0, new List<ShotSummary>());
            }

            return result;
        }
    }
}
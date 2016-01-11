using System;
using System.Collections.Generic;
using System.Linq;
using WTM.Crawler.Domain;
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
        private readonly IDateTimeService dateTimeService;
        const int limitMax = 100;
        const int nbDayFeatureFilms = 30;
        
        public ShotSummaryService(
            Crawler.Services.IShotOverviewService shotOverviewService,
            Crawler.Services.IShotFeatureFilmsService shotFeatureFilmsService,
            Crawler.Services.IShotArchiveService shotArchiveService,
            Crawler.Services.IShotNewSubmissionsService shotNewSubmissionService,
            IDateTimeService dateTimeService)
        {
            this.shotOverviewService = shotOverviewService;
            this.shotFeatureFilmsService = shotFeatureFilmsService;
            this.shotArchiveService = shotArchiveService;
            this.shotNewSubmissionService = shotNewSubmissionService;
            this.dateTimeService = dateTimeService;
        }

        public IShotsResponse Get(ShotsRequest request)
        {
            var date = request?.Date ?? this.dateTimeService.GetDateTime();
            var shotSummaryCollection = this.shotOverviewService.GetShotSummaryByDate(date);

            IShotsResponse result;
            if (shotSummaryCollection != null)
            {
                var skip = request?.Start ?? 0;
                var take = request?.Limit ?? limitMax;
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take).ToList();
                var start = request?.Start ?? 1;
                var totalCount = shotSummaryCollection.Shots.Count;
                result = new ShotsResponse(date, start, totalCount, filteredShots.Select(x => new ShotSummary(x)));
            }
            else
            {
                result = new ShotsResponse(date, 0, 0, new List<ShotSummary>());
            }

            return result;
        }

        public IShotArchivesResponse GetArchives(ShotArchivesRequest request)
        {
            var maxDate = dateTimeService.GetDateTime().Date.AddDays(-30);
            if (request.Date.HasValue && (request.Date.Value > maxDate))
            {
                throw new ArgumentOutOfRangeException("date", string.Format("Date must be before {0}", maxDate));
            }
            var dateCriteria = request.Date.GetValueOrDefault(maxDate);
            var shotSummaryCollection = this.shotArchiveService.GetShotSummaryByDate(dateCriteria);

            IShotArchivesResponse result = null;
            if (shotSummaryCollection != null)
            {
                var skip = request.Start.GetValueOrDefault(0);
                var take = request.Limit.GetValueOrDefault(limitMax);
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);
                result =  new ShotArchivesResponse(filteredShots.Select(x => new ShotSummary(x)));
            }

            return result;
        }

        public IShotFeatureFilmsResponse GetFeatureFilms(ShotFeatureFilmsRequest request)
        {
            var minDate = dateTimeService.GetDateTime().Date.AddDays(-30);
            if (request.Date.HasValue && request.Date.Value < minDate)
            {
                throw new ArgumentOutOfRangeException("date", string.Format("Date must be after {0}", minDate));
            }
            var dateCriteria = request.Date ?? minDate;
            var shotSummaryCollection = this.shotFeatureFilmsService.GetShotSummaryByDate(dateCriteria);

            IShotFeatureFilmsResponse result = null;
            if (shotSummaryCollection != null)
            {
                var skip = request.Start ?? 0;
                var take = request.Limit.GetValueOrDefault(limitMax);
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);
                result = new ShotFeatureFilmsResponse(filteredShots.Select(x => new ShotSummary(x)));
            }

            return result;
        }

        public IShotNewSubmissionsResponse GetNewSubmissions(ShotNewSubmissionsRequest request)
        {
            var shotSummaryCollection = this.shotNewSubmissionService.GetShots();

            IShotNewSubmissionsResponse result = null;
            if (shotSummaryCollection != null)
            {
                var skip = request.Start.GetValueOrDefault(0);
                var take = request.Limit.GetValueOrDefault(limitMax);
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);
                result = new ShotNewSubmissionsResponse(filteredShots.Select(x => new ShotSummary(x)));
            }

            return result;
        }

        public IShotSearchTagResponse SearchByTag(ShotSearchTagRequest request)
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

            return new ShotSearchTagResponse(shotSummaryListFiltered, start, totalCount);
        }
    }
}
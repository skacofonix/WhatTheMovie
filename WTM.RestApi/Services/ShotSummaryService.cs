﻿using System;
using System.Collections.Generic;
using System.Linq;
using WTM.RestApi.Controllers;
using WTM.RestApi.Models;

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
            var date = this.dateTimeService.GetDateTime();
            var shotSummaryCollection = this.shotOverviewService.GetShotSummaryByDate(date);

            IShotsResponse result;
            if (shotSummaryCollection != null)
            {
                var skip = request?.Start ?? 0;
                var take = request?.Limit ?? limitMax;
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take).ToList();
                var start = request?.Start ?? 1;
                var range = new Range(start, start + filteredShots.Count);
                var totalCount = shotSummaryCollection.Shots.Count;
                result = new ShotsResponse(date, range, totalCount, filteredShots.Select(x => new ShotSummary(x)));
            }
            else
            {
                result = new ShotsResponse(date, new Range(0, 0), 0, new List<ShotSummary>());
            }

            return result;
        }

        public IShotByDateResponse GetByDate(ShotByDateRequest request)
        {
            var date = request?.Date ?? this.dateTimeService.GetDateTime();
            var shotSummaryCollection = this.shotOverviewService.GetShotSummaryByDate(date);

            IShotByDateResponse result = null;
            if (shotSummaryCollection != null)
            {
                var skip = request?.Start ?? 0;
                var take = request?.Limit ?? limitMax;
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take).ToList();
                var start = request?.Start ?? 1;
                var range = new Range(start, start + filteredShots.Count);
                var totalCount = shotSummaryCollection.Shots.Count;
                result = new ShotByDateResponse(date, range, totalCount, filteredShots.Select(x => new ShotSummary(x)));
            }
            else
            {
                result = new ShotByDateResponse(date, new Range(0, 0), 0, new List<ShotSummary>());
            }

            return result;
        }

        public IShotSearchTagResponse SearchByTag(ShotSearchTagRequest request)
        {
            var formattedTags = string.Join(" ", request.Tags);
            var shotSummaryCollection = this.shotOverviewService.Search(formattedTags, token: request.Token);

            IShotSearchTagResponse result = null;
            if (shotSummaryCollection != null)
            {
                var skip = request.Start ?? 0;
                var take = request.Limit.GetValueOrDefault(limitMax);
                var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);
                result = new ShotSearchTagResponse(filteredShots.Select(x => new ShotSummary(x)));
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
    }
}
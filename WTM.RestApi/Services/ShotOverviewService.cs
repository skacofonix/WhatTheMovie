using System;
using System.Collections.Generic;
using System.Linq;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotOverviewService : IShotOverviewService
    {
        private readonly Crawler.Services.IShotOverviewService shotOverviewService;
        private readonly Crawler.Services.IShotFeatureFilmsService shotFeatureFilmsService;
        private readonly Crawler.Services.IShotArchiveService shotArchiveService;
        private readonly Crawler.Services.IShotNewSubmissionsService shotNewSubmissionService;
        private readonly IDateTimeService dateTimeService;
        const int limitMax = 100;
        const int nbDayFeatureFilms = 30;
        
        public ShotOverviewService(
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

        public IShotByDateResponse GetByDate(DateTime? date, int? start, int? limit, string token = null)
        {
            var dateCriteria = date ?? dateTimeService.GetDateTime();
            var shotSummaryCollection = this.shotOverviewService.GetShotSummaryByDate(dateCriteria);

            var skip = start ?? 0;
            var take = Math.Min(limitMax, limit ?? shotSummaryCollection.Shots.Count);
            var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);

            IShotByDateResponse response = new ShotByDateResponse(filteredShots.Select(x => new ShotSummaryAdapter(x)));

            return response;
        }

        public IShotSearchTagResponse SearchByTag(List<string> tags, int? start, int? limit, string token = null)
        {
            var formattedTags = string.Join(" ", tags);
            var shotSummaryCollection = this.shotOverviewService.Search(formattedTags, token: token);

            var skip = start ?? 0;
            var take = Math.Min(limitMax, limit ?? shotSummaryCollection.Shots.Count);
            var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);

            IShotSearchTagResponse response = new ShotSearchTagResponse(filteredShots.Select(x => new ShotSummaryAdapter(x)));

            return response;
        }

        public IShotArchivesResponse GetArchives(DateTime? date, int? start, int? limit, string token = null)
        {
            var maxDate = dateTimeService.GetDateTime().Date.AddDays(-30);
            if(date.HasValue && date.Value > maxDate)
            {
                throw new ArgumentOutOfRangeException("date", string.Format("Date must be before {0}", maxDate));
            }
            var dateCriteria = date ?? maxDate;
            var shotSummaryCollection = this.shotArchiveService.GetShotSummaryByDate(dateCriteria);

            var skip = start ?? 0;
            var take = Math.Min(limitMax, limit ?? shotSummaryCollection.Shots.Count);
            var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);

            IShotArchivesResponse result = new ShotArchivesResponse(filteredShots.Select(x => new ShotSummaryAdapter(x)));

            return result;
        }

        public IShotFeatureFilmsResponse GetFeatureFilms(DateTime? date, int? start, int? limit, string token = null)
        {
            var minDate = dateTimeService.GetDateTime().Date.AddDays(-30);
            if (date.HasValue && date.Value < minDate)
            {
                throw new ArgumentOutOfRangeException("date", string.Format("Date must be after {0}", minDate));
            }
            var dateCriteria = date ?? minDate;
            var shotSummaryCollection = this.shotFeatureFilmsService.GetShotSummaryByDate(dateCriteria);

            var skip = start ?? 0;
            var take = Math.Min(limitMax, limit ?? shotSummaryCollection.Shots.Count);
            var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);

            IShotFeatureFilmsResponse result = new ShotFeatureFilmsResponse(filteredShots.Select(x => new ShotSummaryAdapter(x)));

            return result;
        }

        public IShotNewSubmissionsResponse GetNewSubmissions(int? start, int? limit, string token = null)
        {
            var shotSummaryCollection = this.shotNewSubmissionService.GetShots();

            var skip = start ?? 0;
            var take = Math.Min(limitMax, limit ?? shotSummaryCollection.Shots.Count);
            var filteredShots = shotSummaryCollection.Shots.Skip(skip).Take(take);

            IShotNewSubmissionsResponse result = new ShotNewSubmissionsResponse(filteredShots.Select(x => new ShotSummaryAdapter(x)));

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Services
{
    public class ShotOverviewService : IShotOverviewService
    {
        public IEnumerable<ShotOverviewResponse> FindByDate(DateTime? date, int? start, int? limit, string token = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShotOverviewResponse> FindByTag(List<string> tags, int? start, int? limit, string token = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShotOverviewResponse> GetArchives(DateTime? date, int? start, int? limit, string token = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShotOverviewResponse> GetFeatureFilms(DateTime? date, int? start, int? limit, string token = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShotOverviewResponse> GetNewSubmissions(int? start, int? limit, string token = null)
        {
            throw new NotImplementedException();
        }
    }
}
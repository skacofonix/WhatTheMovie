using System;
using System.Collections.Generic;
using WTM.Domain.Response;

namespace WTM.RestApi.Services
{
    public interface IShotOverviewService
    {
        IEnumerable<ShotOverviewResponse> FindByTag(List<string> tags, int? start, int? limit, string token = null);

        IEnumerable<ShotOverviewResponse> FindByDate(DateTime? date, int? start, int? limit, string token = null);

        IEnumerable<ShotOverviewResponse> GetArchives(DateTime? date, int? start, int? limit, string token = null);

        IEnumerable<ShotOverviewResponse> GetFeatureFilms(DateTime? date, int? start, int? limit, string token = null);

        IEnumerable<ShotOverviewResponse> GetNewSubmissions(int? start, int? limit, string token = null);
    }
}

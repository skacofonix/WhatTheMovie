using System;
using System.Collections.Generic;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotOverviewService
    {
        IShotSearchTagResponse SearchByTag(List<string> tags, int? start, int? limit, string token = null);

        IShotByDateResponse GetByDate(DateTime? date, int? start, int? limit, string token = null);

        IShotArchivesResponse GetArchives(DateTime? date, int? start, int? limit, string token = null);

        IShotFeatureFilmsResponse GetFeatureFilms(DateTime? date, int? start, int? limit, string token = null);

        IShotNewSubmissionsResponse GetNewSubmissions(int? start, int? limit, string token = null);
    }
}

using System;
using System.Collections.Generic;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotSummaryService
    {
        IShotSearchTagResponse SearchByTag(ShotSearchTagRequest request);

        IShotByDateResponse GetByDate(ShotByDateRequest request);

        IShotArchivesResponse GetArchives(ShotArchivesRequest request);

        IShotFeatureFilmsResponse GetFeatureFilms(ShotFeatureFilmsRequest request);

        IShotNewSubmissionsResponse GetNewSubmissions(ShotNewSubmissionsRequest request);
    }
}

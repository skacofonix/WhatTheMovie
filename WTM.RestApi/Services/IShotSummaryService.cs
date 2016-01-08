using System;
using System.Collections.Generic;
using WTM.RestApi.Controllers;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotSummaryService
    {
        IShotsResponse Get(ShotsRequest request);

        IShotSearchTagResponse SearchByTag(ShotSearchTagRequest request);

        IShotByDateResponse GetByDate(ShotByDateRequest request);

        IShotArchivesResponse GetArchives(ShotArchivesRequest request);

        IShotFeatureFilmsResponse GetFeatureFilms(ShotFeatureFilmsRequest request);

        IShotNewSubmissionsResponse GetNewSubmissions(ShotNewSubmissionsRequest request);
    }
}


using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotSummaryService
    {
        IShotsResponse Get(ShotsRequest request);

        IShotArchivesResponse GetArchives(ShotArchivesRequest request);

        IShotFeatureFilmsResponse GetFeatureFilms(ShotFeatureFilmsRequest request);

        IShotNewSubmissionsResponse GetNewSubmissions(ShotNewSubmissionsRequest request);

        IShotSearchTagResponse SearchByTag(ShotSearchTagRequest request);
    }
}

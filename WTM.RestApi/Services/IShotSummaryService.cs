
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotSummaryService
    {
        IShotCollectionResponse Get(ShotsRequest request);

        IShotCollectionResponse GetArchives(ShotArchivesRequest request);

        IShotCollectionResponse GetFeatureFilms(ShotFeatureFilmsRequest request);

        IShotCollectionResponse GetNewSubmissions(ShotNewSubmissionsRequest request);

        IShotSearchTagResponse SearchByTag(ShotSearchRequest request);
    }
}

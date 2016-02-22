
using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IShotSummaryService
    {
        IShotCollectionResponse Get(IShotsRequest request);

        IShotCollectionResponse GetArchives(IShotArchivesRequest request);

        IShotCollectionResponse GetFeatureFilms(IShotFeatureFilmsRequest request);

        IShotCollectionResponse GetNewSubmissions(IShotNewSubmissionsRequest request);

        IShotSearchTagResponse Search(IShotSearchRequest request);
    }
}

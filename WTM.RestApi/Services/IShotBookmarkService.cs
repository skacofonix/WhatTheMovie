using System.Collections.Generic;

namespace WTM.RestApi.Services
{
    public interface IShotBookmarkService
    {
        bool Add(int id, string token);

        bool Delete(int id, string token);

        IEnumerable<Domain.Response.ShotOverviewResponse> GetBookmarks(string token, int? start, int? limit);
    }
}
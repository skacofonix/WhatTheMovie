using System.Collections.Generic;
using WTM.RestApi.Models.Response;

namespace WTM.RestApi.Services
{
    public interface IShotBookmarkService
    {
        bool Add(int id, string token);
        bool Delete(int id, string token);
        IEnumerable<ShotOverviewResponse> GetBookmarks(string token, int? start, int? limit);
    }
}
using System.Collections.Generic;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Services
{
    public interface IShotBookmarkService
    {
        bool Add(int id, string token);
        bool Delete(int id, string token);
        IEnumerable<ShotOverviewResponse> Get(string token, int? start, int? limit);
    }
}
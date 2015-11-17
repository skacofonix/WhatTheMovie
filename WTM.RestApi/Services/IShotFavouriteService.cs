using System.Collections.Generic;
using WTM.Domain.Response;

namespace WTM.RestApi.Services
{
    public interface IShotFavouriteService
    {
        bool Add(int id, string token);
        bool Delete(int id, string token);
        IEnumerable<ShotOverviewResponse> Get(string token, int? start, int? limit);
    }
}
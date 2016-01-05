using System.Collections.Generic;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotFavouriteService
    {
        bool Add(int id, string token);
        bool Delete(int id, string token);
        IEnumerable<ShotOverviewResponse> Get(string token, int? start, int? limit);
    }
}
using System.Collections.Generic;
using WTM.RestApi.Models.Response;

namespace WTM.RestApi.Services
{
    public interface IMovieService
    {
        IEnumerable<ShotOverviewResponse> GetShotByMovie(string name, string token = null);
    }
}

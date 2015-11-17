using System.Collections.Generic;
using WTM.Domain.Response;

namespace WTM.RestApi.Services
{
    public interface IMovieService
    {
        IEnumerable<ShotOverviewResponse> GetShotByMovie(string name, string token = null);
    }
}

using System.Collections.Generic;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Services
{
    public interface IMovieService
    {
        IEnumerable<ShotOverviewResponse> GetShotByMovie(string name, string token = null);
    }
}

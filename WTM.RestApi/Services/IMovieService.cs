using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IMovieService
    {
        IShotSearchMovieResponse GetShotByMovie(ShotSearchMovieRequest request);
    }
}
using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IMovieService
    {
        IShotSearchMovieResponse GetShotByMovie(ShotSearchMovieRequest request);
    }
}
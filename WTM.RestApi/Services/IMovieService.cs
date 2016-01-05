using System.Collections.Generic;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IMovieService
    {
        IShotSearchMovieResponse GetShotByMovie(string name, string token = null);
    }
}

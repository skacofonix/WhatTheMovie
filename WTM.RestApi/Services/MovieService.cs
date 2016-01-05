using System;
using System.Collections.Generic;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class MovieService : IMovieService
    {
        public IShotSearchMovieResponse GetShotByMovie(string name, string token = null)
        {
            throw new NotImplementedException();
        }
    }
}
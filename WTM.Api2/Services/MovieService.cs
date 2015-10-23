using System;
using System.Collections.Generic;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Services
{
    public class MovieService : IMovieService
    {
        public IEnumerable<ShotOverviewResponse> GetShotByMovie(string name, string token = null)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using WTM.RestApi.Models.Response;

namespace WTM.RestApi.Services
{
    public class MovieService : IMovieService
    {
        public IEnumerable<ShotOverviewResponse> GetShotByMovie(string name, string token = null)
        {
            throw new NotImplementedException();
        }
    }
}
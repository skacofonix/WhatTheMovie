using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Domain;

namespace WTM.Api.Core.Services
{
    public class MovieService : IMovieService
    {
        public Movie GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieOverview> Search(string title)
        {
            throw new NotImplementedException();
        }
    }
}

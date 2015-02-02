using System.Collections.Generic;
using WTM.Domain;

namespace WTM.Api.Core.Services
{
    public interface IMovieService
    {
        Movie GetByTitle(string title);

        IEnumerable<MovieOverview> Search(string title);
    }

    public class MovieOverview
    {
    }
}
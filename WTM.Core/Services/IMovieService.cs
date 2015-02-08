using System.Collections.Generic;
using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Core.Services
{
    public interface IMovieService
    {
        IMovie GetByTitle(string title);

        IEnumerable<IMovieSummary> Search(string title);
    }
}
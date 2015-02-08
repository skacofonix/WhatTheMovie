using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Core.Services
{
    public interface IMovieService
    {
        IMovie GetByTitle(string title);

        IMovieSummaryCollection Search(string title);
    }
}
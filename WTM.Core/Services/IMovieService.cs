using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IMovieService
    {
        Movie GetByTitle(string title);

        MovieSummaryCollection Search(string title, int? page = null);
    }
}
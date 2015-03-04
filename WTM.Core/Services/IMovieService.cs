using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IMovieService
    {
        Movie GetById(string id);

        MovieSummaryCollection Search(string title, int? page = null);
    }
}
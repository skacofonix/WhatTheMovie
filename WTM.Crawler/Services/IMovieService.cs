using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IMovieService
    {
        Movie GetById(string id);

        MovieSummaryCollection Search(string title, int? page = null);
    }
}
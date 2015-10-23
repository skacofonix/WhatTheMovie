using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IShotService
    {
        Shot GetRandomShot(string token = null);

        Shot GetById(int id, string token = null);

        Domain.GuessTitleResponse GuessTitle(int id, string title, string token = null);

        Domain.GuessTitleResponse GetSolution(int id, string token = null);

        Rate Rate(int id, int score, string token = null);

        ShotSummaryCollection Search(string tag, int? page = null, string token = null);
    }
}
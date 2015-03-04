using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IShotService
    {
        Shot GetRandomShot();

        Shot GetById(int id);

        GuessTitleResponse GuessTitle(int id, string title);

        GuessTitleResponse GetSolution(int id);

        Rate Rate(int id, int score);

        ShotSummaryCollection Search(string tag, int? page = null);
    }
}
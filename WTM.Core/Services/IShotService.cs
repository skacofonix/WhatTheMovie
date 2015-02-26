using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IShotService
    {
        Shot GetRandomShot();

        Shot GetShotById(int id);

        GuessTitleResponse GuessTitle(int shotId, string title);

        Movie ShowSolution(int shotId);

        Rate Rate(int score);

        ShotSummaryCollection Search(string tag, int? page = null);
    }
}
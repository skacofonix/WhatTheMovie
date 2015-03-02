using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IShotService
    {
        Shot GetRandomShot();

        Shot GetShotById(int id);

        GuessTitleResponse GuessTitle(int id, string title);

        GuessTitleResponse ShowSolution(int id);

        Rate Rate(int id, int score);

        ShotSummaryCollection Search(string tag, int? page = null);
    }
}
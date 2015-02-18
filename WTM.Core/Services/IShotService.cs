using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Core.Services
{
    public interface IShotService
    {
        IShot GetRandomShot();

        IShot GetShotById(int id);

        IGuessTitleResponse GuessTitle(int shotId, string title);

        IMovie ShowSolution(int shotId);

        IRate Rate(int score);

        IShotSummaryCollection Search(string tag, int? page = null);
    }
}
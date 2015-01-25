using System.Collections.Generic;
using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IShotService
    {
        Shot GetRandomShot();

        Shot GetShotById(int id);

        Shot GetFirstShot(Shot currentShot = null);

        Shot GetPreviousShot(Shot currentShot);

        Shot GetPreviousUnsolvdShot(Shot currentShot);

        Shot GetNextUnsolvedShot(Shot currentShot);

        Shot GetNextShot(Shot currentShot);

        Shot GetLastShotShot(Shot currentShot = null);

        IEnumerable<Shot> Search(string tag);

        bool GuessTitle(Shot shot, string title);

        bool ShowSolution(Shot shot);

        bool Rate(int score);
    }
}
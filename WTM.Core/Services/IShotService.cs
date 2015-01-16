using System.Collections.Generic;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal interface IShotService
    {
        Shot GetRandomShot();

        Shot GetShotById(int id);

        Shot GetFirstShot(Shot currentShot = null);

        Shot GetPreviousShot(Shot currentShot = null);

        Shot GetPreviousUnsolvdShot(Shot currentShot = null);

        Shot GetNextUnsolvedShot(Shot currentShot = null);

        Shot GetNextShot(Shot currentShot = null);

        Shot GetLastShot(Shot currentShot = null);

        IEnumerable<Shot> Search(string criteria);
            
        GuessTitleResponse GuessTitle(int shotId, string title);

        ShowSolutionResponse ShowSolution(int shotId);

        bool Rate(int score);
    }
}
using System.Collections.Generic;
using WTM.Core.Services;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Services
{
    internal interface IShotService
    {
        Shot GetRandomShot();

        Shot GetShotById(int id);

        Shot GetFirstShot(Shot currentShot = null);

        Shot GetPreviousShot(Shot currentShot);

        Shot GetPreviousUnsolvdShot(Shot currentShot);

        Shot GetNextUnsolvedShot(Shot currentShot);

        Shot GetNextShot(Shot currentShot);

        Shot GetLastShot(Shot currentShot = null);

        IEnumerable<Shot> Search(string criteria);
            
        GuessTitleResponse GuessTitle(int shotId, string title);

        ShowSolutionResponse ShowSolution(int shotId);

        bool Rate(int score);
    }
}
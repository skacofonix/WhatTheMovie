using System.Collections.Generic;
using WTM.Domain;

namespace WTM.WebsiteClient.Services
{
    public interface IShotService
    {
        Shot GetRandomShot();

        Shot GetShotById(int id);

        IEnumerable<Shot> Search(string criteria);
            
        GuessTitleResponse GuessTitle(int shotId, string title);

        ShowSolutionResponse ShowSolution(int shotId);

        bool Rate(int score);
    }
}
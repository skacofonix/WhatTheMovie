using System;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.Services
{
    public class ShotService : IShotService
    {
        public Shot GetRandomShot()
        {
            throw new NotImplementedException();
        }

        public Shot GetShotById(int id)
        {
            throw new NotImplementedException();
        }

        public GuessTitleResponse GuessTitle(int shotId, string title)
        {
            throw new NotImplementedException();
        }

        public Movie ShowSolution(int shotId)
        {
            throw new NotImplementedException();
        }

        public Rate Rate(int score)
        {
            throw new NotImplementedException();
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using WTM.Core.Services;
using WTM.Domain.Interfaces;

namespace WTM.Mobile.Core.Services
{
    public class ShotService : IShotService
    {
        public IShot GetRandomShot()
        {
            throw new NotImplementedException();
        }

        public IShot GetShotById(int id)
        {
            throw new NotImplementedException();
        }

        public IGuessTitleResponse GuessTitle(int shotId, string title)
        {
            throw new NotImplementedException();
        }

        public IMovie ShowSolution(int shotId)
        {
            throw new NotImplementedException();
        }

        public IRate Rate(int score)
        {
            throw new NotImplementedException();
        }

        public IShotSummaryCollection Search(string tag, int? page = null)
        {
            throw new NotImplementedException();
        }
    }
}
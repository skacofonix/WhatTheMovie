﻿using System.Collections.Generic;
using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IShotService
    {
        IShot GetRandomShot();

        IShot GetShotById(int id);

        IGuessTitleResponse GuessTitle(int shotId, string title);

        IMovie ShowSolution(int shotId);

        IRate Rate(int score);

        IEnumerable<IShot> Search(string tag);
    }
}
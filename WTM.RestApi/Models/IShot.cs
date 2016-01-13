﻿using System;
using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShot : IIdentifiable
    {
        int Id { get; }

        Uri Image { get; }

        //public Navigation Navigation { get; set; }

        string Poster { get; }

        string Updater { get; }

        string FirstSolver { get; }

        int? NbSolver { get; }

        DateTime PublidationDate { get; }

        int? NumberOfDayBeforeSolution { get; }

        //SnapshotDifficulty? Difficulty { get; }

        ShotUserStatus UserStatus { get; }

        bool IsGore { get; }

        bool IsNudity { get; }

        IList<string> Tags { get; }

        IList<string> Languages { get; }

        //Rate Rate { get; }

        bool? IsFavourited { get; }

        bool? IsBookmarked { get; }

        bool? IsSolutionAvailable { get; }

        bool? IsVoteDeletation { get; }

        int NumberOfFavourited { get; }
    }
}
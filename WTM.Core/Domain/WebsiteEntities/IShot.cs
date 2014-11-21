using System;
using System.Collections.Generic;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Domain.WebsiteEntities
{
    public interface IShot : IWebsiteEntityBase
    {
        #region Navigation

        int? FirstShotId { get; }

        int? PreviousShotId { get; }

        int? PreviousUnsolvedShotId { get; }

        int? ShotId { get; }

        int? NextUnsolvedShotId { get; }

        int? NextShotId { get; }

        int? LastShotId { get; }

        #endregion

        #region Snapshot

        DateTime? PostedDate { get; }

        string PostedBy { get; }

        string FirstSolver { get; }

        bool? IsSolved { get; }

        int? NbSolver { get; }

        string ImageUrl { get; }

        #endregion

        bool? IncludeArchive { get; }
        bool? IncludeSolvedSHots { get; }
        bool? IsBookmark { get; }
        bool? IsFavourite { get; }
        bool? IsSolutionAvailible { get; }
        List<string> Languages { get; }
        string MovieTitle { get; }
        int? NbFavourited { get; }
        int? NbRaters { get; }
        double? Rate { get; }
        int? RemainingDaysBeforeSolution { get; }
        DateTime SolutionAvailableDate { get; }
        List<string> Tags { get; }
        List<string> Comments { get; }
        string Difficulty { get; }
    }
}

using System;
using System.Collections.Generic;
using WTM.CorePCL.Domain.WebsiteEntities.Base;

namespace WTM.CorePCL.Domain.WebsiteEntities
{
    public interface IShot : IWebsiteEntityBase
    {
        List<string> Comments { get; set; }
        string Difficulty { get; set; }
        int? FirstShotId { get; set; }
        string FirstSolver { get; set; }
        string ImageUrl { get; set; }
        bool? IncludeArchive { get; set; }
        bool? IncludeSolvedSHots { get; set; }
        bool? IsBookmark { get; set; }
        bool? IsFavourite { get; set; }
        bool? IsSolutionAvailible { get; set; }
        bool? IsSolved { get; set; }
        bool? IsVoteDeletation { get; set; }
        List<string> Languages { get; set; }
        int? LastShotId { get; set; }
        string MovieTitle { get; set; }
        int? NbFavourited { get; set; }
        int? NbRaters { get; set; }
        int? NbSolver { get; set; }
        int? NextShotId { get; set; }
        int? NextUnsolvedShotId { get; set; }
        string PostedBy { get; set; }
        DateTime? PostedDate { get; set; }
        int? PreviousShotId { get; set; }
        int? PreviousUnsolvedShotId { get; set; }
        double? Rate { get; set; }
        int? RemainingDaysBeforeSolution { get; set; }
        int? ShotId { get; set; }
        DateTime SolutionAvailableDate { get; set; }
        List<string> Tags { get; set; }
    }
}

using System;
using System.Collections.Generic;
using WTM.CorePCL.Application.Attributes;

namespace WTM.CorePCL.Domain.WebsiteEntities
{
    public class Shot : IShot
    {
        #region Navigation
        
        public int? FirstShotId { get; set; }

        public int? PreviousShotId { get; set; }

        public int? PreviousUnsolvedShotId { get; set; }

        public int? ShotId { get; set; }

        public int? NextShotId { get; set; }

        public int? NextUnsolvedShotId { get; set; }

        public int? LastShotId { get; set; }

        #endregion

        #region Snapshot

        public DateTime? PostedDate { get; set; }

        public string PostedBy { get; set; }

        public string FirstSolver { get; set; }
        
        public bool? IsSolved { get; set; }
        
        public int? NbSolver { get; set; }

        public string ImageUrl { get; set; }

        #endregion
        
        #region Solution
		 
        [AuthenticatedUser]
        public bool? IsFavourite { get; set; }

        [AuthenticatedUser]
        public bool? IsBookmark { get; set; }

        [AuthenticatedUser]
        public bool? IsVoteDeletation { get; set; }

        public string MovieTitle { get; set; }
        public bool? IsSolutionAvailible { get; set; }

        public DateTime SolutionAvailableDate { get; set; }
        public int? RemainingDaysBeforeSolution { get; set; }

        public List<string> Tags { get; set; }

        public List<string> Languages { get; set; }
        
        public List<string> Comments { get; set; }
        
        public double? Rate { get; set; }
        
        public int? NbRaters { get; set; }

        public int? NbFavourited { get; set; }

        public string Difficulty { get; set; }
        public bool? IncludeArchive { get; set; }
        public bool? IncludeSolvedSHots { get; set; }

	    #endregion
    }
}
using System;
using System.Collections.Generic;
using WTM.Core.Application.Attributes;

namespace WTM.Core.Domain.WebsiteEntities
{
    public class Shot : IShot
    {
        #region Navigation

        [HtmlParser(@"//a[@id='first_shot_link']/@href", @"/shot/(\d)")]
        public int? FirstShotId { get; set; }

        [HtmlParser(@"//a[@id='prev_shot_link']/@href", @"/shot/(\d)")]
        public int? PreviousShotId { get; set; }

        [HtmlParser(@"//li[@id='prev_unsolved_shot']/a/@href", @"/shot/(\d)")]
        public int? PreviousUnsolvedShotId { get; set; }

        [HtmlParser(@"//li[@class='number']", @"(\d)")]
        public int? ShotId { get; set; }

        [HtmlParser(@"//li[@id='next_unsolved_shot']/a/@href", @"/shot/(\d)")]
        public int? NextUnsolvedShotId { get; set; }

        [HtmlParser(@"//a[@id='next_shot_link']/@href", @"/shot/(\d)")]
        public int? NextShotId { get; set; }

        [HtmlParser(@"//a[@id='last_shot_link']/@href", @"/shot/(\d)")]
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
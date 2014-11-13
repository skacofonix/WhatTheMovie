using System;
using System.Collections.Generic;
using WTM.Core.Application.Attributes;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Domain.WebsiteEntities
{
    public interface IShot : IWebsiteEntityBase
    {
        #region Navigation

        [HtmlParser(@"//a[@id='first_shot_link']/@href", @"/shot/(\d)")]
        int? FirstShotId { get; }

        [HtmlParser(@"//a[@id='prev_shot_link']/@href", @"/shot/(\d)")]
        int? PreviousShotId { get; }

        [HtmlParser(@"//li[@id='prev_unsolved_shot']/a/@href", @"/shot/(\d)")]
        int? PreviousUnsolvedShotId { get; }

        [HtmlParser(@"//li[@class='number']", @"(\d)")]
        int? ShotId { get; }

        [HtmlParser(@"//li[@id='next_unsolved_shot']/a/@href", @"/shot/(\d)")]
        int? NextUnsolvedShotId { get; }

        [HtmlParser(@"//a[@id='next_shot_link']/@href", @"/shot/(\d)")]
        int? NextShotId { get; }

        [HtmlParser(@"//a[@id='last_shot_link']/@href", @"/shot/(\d)")]
        int? LastShotId { get; }

        #endregion

        #region Snapshot

        [HtmlParser(@"//div[@id='hidden_date']")]
        DateTime? PostedDate { get; }

        [HtmlParser(@"//li[@id='postername']/a")]
        string PostedBy { get; }

        //[HtmlParser(@"//li[@id='postername']/a")]
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
        bool? IsVoteDeletation { get; }
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

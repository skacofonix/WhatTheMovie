using System;
using System.Collections.Generic;
using WTM.Core.Application.Attributes;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class Shot : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        #region Navigation

        [StringParser(@"//a[@id='first_shot_link']/@href", @"/shot/(\d*)")]
        public int? FirstShotId { get; set; }

        [StringParser(@"//a[@id='prev_shot_link']/@href", @"/shot/(\d*)")]
        public int? PreviousShotId { get; set; }

        [StringParser(@"//li[@id='prev_unsolved_shot']/a/@href", @"/shot/(\d*)")]
        public int? PreviousUnsolvedShotId { get; set; }

        [StringParser(@"//li[@class='number']", @"(\d*)")]
        public int? ShotId { get; set; }

        [StringParser(@"//li[@id='next_unsolved_shot']/a/@href", @"/shot/(\d*)")]
        public int? NextUnsolvedShotId { get; set; }

        [StringParser(@"//a[@id='next_shot_link']/@href", @"/shot/(\d*)")]
        public int? NextShotId { get; set; }

        [StringParser(@"//a[@id='last_shot_link']/@href", @"/shot/(\d*)")]
        public int? LastShotId { get; set; }

        #endregion

        #region Snapshot

        [StringParser(@"//div[@id='hidden_date']")]
        public DateTime? PostedDate { get; set; }

        [StringParser(@"//li[@id='postername']/a")]
        public string PostedBy { get; set; }

        [StringParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo2']/li/a")]
        public string UpdatedBy { get; set; }

        [StringParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo']/li[3]/a[@class='nametaglink']")]
        public string FirstSolver { get; set; }

        [BooleanParser(@"//li[@class='unsolved']", null, true)]
        public bool? IsSolved { get; set; }

        [StringParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo']/li[@class='solved']", @"status: solved \((\d*)\)")]
        public int? NbSolver { get; set; }

        [StringParser(@"/html/body[@class='black']/div[@id='container']/script", @"var imageSrc = '(/system/images/stills/normal/([a-z0-9]*)/([a-z0-9]*.jpg))';")]
        public string ImageUrl { get; set; }

        #endregion

        #region Solution

        [AuthenticatedUser]
        [BooleanParser(@"//a[@id='favbutton']/onclick", @"((un)?fav)")]
        public bool? IsFavourite { get; set; }

        [AuthenticatedUser]
        [BooleanParser(@"//a[@id='bookbutton']/onclick", @"((un)?watch)")]
        public bool? IsBookmark { get; set; }

        public string MovieTitle { get; set; }

        [BooleanParser(@"//a[@id='solucebutton']")]
        public bool? IsSolutionAvailible { get; set; }

        public DateTime SolutionAvailableDate { get; set; }
        public int? RemainingDaysBeforeSolution { get; set; }

        public List<string> Tags { get; set; }

        public List<string> Languages { get; set; }

        public List<string> Comments { get; set; }

        public decimal? Rate { get; set; }

        public int? NbRaters { get; set; }

        public int? NbFavourited { get; set; }

        public string Difficulty { get; set; }
        public bool? IncludeArchive { get; set; }
        public bool? IncludeSolvedSHots { get; set; }

        #endregion
    }
}
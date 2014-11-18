using System;
using System.Collections.Generic;
using WTM.Core.Application.Attributes;

namespace WTM.Core.Domain.WebsiteEntities
{
    public class Shot : IShot
    {

        #region Navigation

        [HtmlParser(@"//a[@id='first_shot_link']/@href", @"/shot/(\d*)")]
        public int? FirstShotId { get; private set; }

        [HtmlParser(@"//a[@id='prev_shot_link']/@href", @"/shot/(\d*)")]
        public int? PreviousShotId { get; private set; }

        [HtmlParser(@"//li[@id='prev_unsolved_shot']/a/@href", @"/shot/(\d*)")]
        public int? PreviousUnsolvedShotId { get; private set; }

        [HtmlParser(@"//li[@class='number']", @"(\d*)")]
        public int? ShotId { get; private set; }

        [HtmlParser(@"//li[@id='next_unsolved_shot']/a/@href", @"/shot/(\d*)")]
        public int? NextUnsolvedShotId { get; private set; }

        [HtmlParser(@"//a[@id='next_shot_link']/@href", @"/shot/(\d*)")]
        public int? NextShotId { get; private set; }

        [HtmlParser(@"//a[@id='last_shot_link']/@href", @"/shot/(\d*)")]
        public int? LastShotId { get; private set; }

        #endregion

        #region Snapshot

        [HtmlParser(@"//div[@id='hidden_date']")]
        public DateTime? PostedDate { get; private set; }

        [HtmlParser(@"//li[@id='postername']/a")]
        public string PostedBy { get; private set; }

        [HtmlParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo']/li[3]/a[@class='nametaglink']")]
        public string FirstSolver { get; private set; }

        public bool? IsSolved { get; private set; }

        [HtmlParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo']/li[@class='solved']", @"status: solved \(\d*\)")]
        public int? NbSolver { get; private set; }

        [HtmlParser(@"/html/body[@class='black']/div[@id='container']/script", @"var imageSrc = '(/system/images/stills/normal/({a-z0-9})*/({a-z0-9})*.jpg)';")]
        public string ImageUrl { get; private set; }

        #endregion
        
        #region Solution
		 
        [AuthenticatedUser]
        public bool? IsFavourite { get; private set; }

        [AuthenticatedUser]
        public bool? IsBookmark { get; private set; }

        [AuthenticatedUser]
        public bool? IsVoteDeletation { get; private set; }

        public string MovieTitle { get; private set; }
        public bool? IsSolutionAvailible { get; private set; }

        public DateTime SolutionAvailableDate { get; private set; }
        public int? RemainingDaysBeforeSolution { get; private set; }

        [HtmlParser(@"//ul[@id='shot_tag_list']/li/a[1]")]
        public List<string> Tags
        {
            get { return tags; }
            private set { tags = value; }
        }
        private List<string> tags;

        [HtmlParser(
            @"//div[@id='solve_station']/div[@class='col_center clearfix']/ul[@class='language_flags']/li/img/@src",
            @"images/flags/(({a-z})*).png")]
        public List<string> Languages
        {
            get { return languages; }
            private set { languages = value; }
        }
        private List<string> languages;

        public List<string> Comments { get; private set; }

        public double? Rate { get; private set; }

        public int? NbRaters { get; private set; }

        public int? NbFavourited { get; private set; }

        public string Difficulty { get; private set; }
        public bool? IncludeArchive { get; private set; }
        public bool? IncludeSolvedSHots { get; private set; }

	    #endregion
    }
}
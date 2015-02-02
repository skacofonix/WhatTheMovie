using System;
using System.Collections.Generic;
using WTM.WebsiteClient.Application.Attributes;

namespace WTM.WebsiteClient.Domain
{
    public interface IShot
    {
        DateTime ParseDateTime { get; }

        [StringParser(@"//a[@id='first_shot_link']/@href", @"/shot/(\d*)")]
        int? FirstShotId { get; set; }

        [StringParser(@"//a[@id='prev_shot_link']/@href", @"/shot/(\d*)")]
        int? PreviousShotId { get; set; }

        [StringParser(@"//li[@id='prev_unsolved_shot']/a/@href", @"/shot/(\d*)")]
        int? PreviousUnsolvedShotId { get; set; }

        [StringParser(@"//li[@class='number']", @"(\d*)")]
        int? ShotId { get; set; }

        [StringParser(@"//li[@id='next_unsolved_shot']/a/@href", @"/shot/(\d*)")]
        int? NextUnsolvedShotId { get; set; }

        [StringParser(@"//a[@id='next_shot_link']/@href", @"/shot/(\d*)")]
        int? NextShotId { get; set; }

        [StringParser(@"//a[@id='last_shot_link']/@href", @"/shot/(\d*)")]
        int? LastShotId { get; set; }

        [StringParser(@"//div[@id='hidden_date']")]
        DateTime? PostedDate { get; set; }

        [StringParser(@"//li[@id='postername']/a")]
        string PostedBy { get; set; }

        [StringParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo2']/li/a")]
        string UpdatedBy { get; set; }

        [StringParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo']/li[3]/a[@class='nametaglink']")]
        string FirstSolver { get; set; }

        [BooleanParser(@"//li[@class='unsolved']", null, true)]
        bool? IsSolved { get; set; }

        bool? IsSolvedByUser { get; set; }

        [StringParser(@"//div[@id='main_shot']/ul[@class='nav_shotinfo']/li[@class='solved']", @"status: solved \((\d*)\)")]
        int? NbSolver { get; set; }

        [StringParser(@"/html/body[@class='black']/div[@id='container']/script", @"var imageSrc = '(/system/images/stills/normal/([a-z0-9]*)/([a-z0-9]*.jpg))';")]
        string ImageUrl { get; set; }

        [AuthenticatedUser]
        [BooleanParser(@"//a[@id='favbutton']/onclick", @"((un)?fav)")]
        bool? IsFavourite { get; set; }

        [AuthenticatedUser]
        [BooleanParser(@"//a[@id='bookbutton']/onclick", @"((un)?watch)")]
        bool? IsBookmark { get; set; }

        string MovieTitle { get; set; }

        [BooleanParser(@"//a[@id='solucebutton']")]
        bool? IsSolutionAvailible { get; set; }

        DateTime SolutionAvailableDate { get; set; }
        int? RemainingDaysBeforeSolution { get; set; }
        List<string> Tags { get; set; }
        List<string> Languages { get; set; }
        List<string> Comments { get; set; }
        decimal? Rate { get; set; }
        int? NbRaters { get; set; }
        int? NbFavourited { get; set; }
        string Difficulty { get; set; }
        bool? IncludeArchive { get; set; }
        bool? IncludeSolvedSHots { get; set; }
    }
}
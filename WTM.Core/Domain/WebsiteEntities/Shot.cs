using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Core.Application.Attributes;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Domain.WebsiteEntities
{
    public class Shot : WebsiteEntityBase
    {
        [HtmlParser(XPathExpression = "/html/body[@class='black']/div[@id='container']/div[@id='main_shot']/ul[@id='nav_shots']/li[1]/a[@id='first_shot_link']", Pattern=@"/shot/(\d*)")]
        public int? FirstShotId { get; set; }

        public int? PreviousShotId { get; set; }
        public int? PreviousUnsolvedShotId { get; set; }
        public int? ShotId { get; set; }
        public int? NextShotId { get; set; }
        public int? NextUnsolvedShotId { get; set; }
        public int? LastShotId { get; set; }
        
        public DateTime? PostedDate { get; set; }
        public string PostedBy { get; set; }
        public string FirstSolver { get; set; }
        public bool? IsSolved { get; set; }
        public int? NbSolver { get; set; }

        public string ImageUrl { get; set; }

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
    }
}
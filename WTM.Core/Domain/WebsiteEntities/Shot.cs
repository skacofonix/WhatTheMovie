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
        #region Navigation
        
        [HtmlParser("$('#first_shot_link').attr('href')", @"/shot/(\d*)")]
        public int? FirstShotId { get; set; }

        [HtmlParser("$('#prev_shot').attr('href')", @"/shot/(\d*)")]
        public int? PreviousShotId { get; set; }

        [HtmlParser("$('#prev_unsolved_shot').attr('href')", @"/shot/(\d*)")]
        public int? PreviousUnsolvedShotId { get; set; }

        [HtmlParser("$('#nav_shots li.number').html()", @"(\d*)")]
        public int? ShotId { get; set; }

        [HtmlParser("$('#next_shot').attr('href')", @"/shot/(\d*)")]
        public int? NextShotId { get; set; }

        [HtmlParser("$('#next_unsolved_shot').attr('href')", @"/shot/(\d*)")]
        public int? NextUnsolvedShotId { get; set; }

        [HtmlParser("$('#last_shot_link').attr('href')", @"/shot/(\d*)")]
        public int? LastShotId { get; set; }

        #endregion

        #region Snapshot

        [HtmlParser("$('#hidden_date').html()")]
        public DateTime? PostedDate { get; set; }

        [HtmlParser("$('#postername a:first').html()")]
        public string PostedBy { get; set; }

        [HtmlParser("$('#main_shot li:contains(\"first solved by\") a').html()")]
        public string FirstSolver { get; set; }
        
        public bool? IsSolved { get; set; }
        
        [HtmlParser("$('#main_shot li.solved')", @"status: solved \((\d*)\)")]
        public int? NbSolver { get; set; }

        [HtmlParser("$('script:contains(\"var imageSrc\")')", "var imageSrc = '([a-z0-9/.]*)';")]
        public string ImageUrl { get; set; }

        #endregion
        
        #region Solution
		 
        [AuthenticatedUser]
        [HtmlParser("$('#favbutton').attr('onclick')", @"new Ajax.Request\('/shot/\d*/(fav|unfav)'")]
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

        [HtmlParser("$('#solve_station ul.language_flags img')", "/images/flags/([a-z]{2,3}).png")]
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
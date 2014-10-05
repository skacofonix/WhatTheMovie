using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Domain.WebsiteEntities
{
    public class Shot
    {
        public int FirstShotId { get; set; }
        public int PreviousShotId { get; set; }
        public int ShotId { get; set; }
        public int NextShotId { get; set; }
        public int LastShotId { get; set; }

        public DateTime PostedDate { get; set; }
        public string PostedBy { get; set; }
        public string FirstSolver { get; set; }
        public bool IsSolved { get; set; }
        public int NbSolver { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFavourite { get; set; }
        public bool IsBookmark { get; set; }
        public bool IsVoteDeletation { get; set; }

        public string MovieTitle { get; set; }
        public bool IsSolutionAvaible { get; set; }

        public DateTime SolutionAvailableDate { get; set; }
        public int RemainingDaysBeforeSolution { get; set; }

        public List<string> Tags { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Comments { get; set; }
        public double Rate { get; set; }
        public int NbRaters { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class Bookmark : IBookmark
    {
        public DateTime ParseDateTime { get; private set; }
        public TimeSpan ParseDuration { get; private set; }
        public string ShotUrl { get; set; }
        public int? ShotId { get; set; }
        public string ImageUrl { get; set; }
        public int? NbDaysLeft { get; set; }
        public bool SolutionAvailable { get; set; }
    }
}

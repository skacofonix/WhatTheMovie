using System;
using System.Collections.Generic;
using System.Text;
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

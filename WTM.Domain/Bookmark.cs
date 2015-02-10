using System;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class Bookmark : IBookmark
    {
        public DateTime ParseDateTime { get; set; }
        public TimeSpan ParseDuration { get; set; }
        public string ShotUrl { get; set; }
        public int? ShotId { get; set; }
        public string ImageUrl { get; set; }
        public int? NbDaysLeft { get; set; }
        public bool SolutionAvailable { get; set; }
    }
}
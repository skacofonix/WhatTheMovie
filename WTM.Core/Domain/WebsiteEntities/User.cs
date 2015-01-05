using System;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class User : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public double? Score { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public int? PlayingSinceYear { get; set; }
        public int? PlayingSinceMonth { get; set; }
        public string About { get; set; }
        public int? FeatureFilmsSolved;
        public int? SnapshotSolved { get; set; }
        public decimal? ReceivingRating { get; set; }
        public decimal? FavouritedRating { get; set; }

        public User()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}

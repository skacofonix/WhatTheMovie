using System;
using System.Collections.Generic;

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
        public int? UploadFeatureFilmSnapshots { get; set; }
        public int? UploadSnapshotsOfTheDay { get; set; }
        public int? UploadVaultSnapshots { get; set; }
        public int? UploadRejectedSnapshots { get; set; }
        public int? UploadCharacterSnapshots { get; set; }
        public int? UploadTitleSnapshots { get; set; }
        public int? UploadReplacementSnapshots { get; set; }
        public int? FavouriteSnapshots { get; set; }
        public int? FavouriteMovies { get; set; }
        public int? FavouriteCharacters { get; set; }
        public int? FavouriteSeries { get; set; }
        public List<string> Friends { get; set; }
        public List<KeyValuePair<string, string>> MemorabiliaList { get; set; }
        public string ImageUrl { get; set; }

        public User()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}

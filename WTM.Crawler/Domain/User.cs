using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class User : IWebsiteEntity, IUserConnected
    {
        public User()
        {
            Friends = new List<string>();
            MemorabiliaList = new List<Memorabilia>();
        }

        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        public Uri Uri { get; set; }

        public string ConnectedUsername { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Level { get; set; }

        [DataMember]
        public double? Score { get; set; }

        [DataMember]
        public int? Age { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public int? PlayingSinceYear { get; set; }

        [DataMember]
        public int? PlayingSinceMonth { get; set; }

        [DataMember]
        public string About { get; set; }

        [DataMember]
        public int? FeatureFilmsSolved { get; set; }

        [DataMember]
        public int? SnapshotSolved { get; set; }

        [DataMember]
        public decimal? ReceivingRating { get; set; }

        [DataMember]
        public decimal? FavouritedRating { get; set; }

        [DataMember]
        public int? UploadFeatureFilmSnapshots { get; set; }

        [DataMember]
        public int? UploadSnapshotsOfTheDay { get; set; }

        [DataMember]
        public int? UploadVaultSnapshots { get; set; }

        [DataMember]
        public int? UploadRejectedSnapshots { get; set; }

        [DataMember]
        public int? UploadCharacterSnapshots { get; set; }

        [DataMember]
        public int? UploadTitleSnapshots { get; set; }

        [DataMember]
        public int? UploadReplacementSnapshots { get; set; }

        [DataMember]
        public int? FavouriteSnapshots { get; set; }

        [DataMember]
        public int? FavouriteMovies { get; set; }

        [DataMember]
        public int? FavouriteCharacters { get; set; }

        [DataMember]
        public int? FavouriteSeries { get; set; }

        [DataMember]
        public IList<string> Friends { get; set; }

        [DataMember]
        public IList<Memorabilia> MemorabiliaList { get; set; }

        [DataMember]
        public Uri ImageUri { get; set; }
    }
}
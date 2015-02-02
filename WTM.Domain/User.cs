using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class User : IUser
    {
        public User()
        {
            Friends = new List<string>();
            MemorabiliaList = new List<IMemorabilia>();
        }
        
        [DataMember]
        public string Name { get; private set; }
        
        [DataMember]
        public string Level { get; private set; }
        
        [DataMember]
        public double? Score { get; private set; }
        
        [DataMember]
        public int? Age { get; private set; }
        
        [DataMember]
        public Gender Gender { get; private set; }
        
        [DataMember]
        public string Country { get; private set; }
        
        [DataMember]
        public int? PlayingSinceYear { get; private set; }
        
        [DataMember]
        public int? PlayingSinceMonth { get; private set; }
        
        [DataMember]
        public string About { get; private set; }
        
        [DataMember]
        public int? FeatureFilmsSolved { get; private set; }
        
        [DataMember]
        public int? SnapshotSolved { get; private set; }
        
        [DataMember]
        public decimal? ReceivingRating { get; private set; }
        
        [DataMember]
        public decimal? FavouritedRating { get; private set; }
        
        [DataMember]
        public int? UploadFeatureFilmSnapshots { get; private set; }
        
        [DataMember]
        public int? UploadSnapshotsOfTheDay { get; private set; }
        
        [DataMember]
        public int? UploadVaultSnapshots { get; private set; }
        
        [DataMember]
        public int? UploadRejectedSnapshots { get; private set; }
        
        [DataMember]
        public int? UploadCharacterSnapshots { get; private set; }
        
        [DataMember]
        public int? UploadTitleSnapshots { get; private set; }
        
        [DataMember]
        public int? UploadReplacementSnapshots { get; private set; }
        
        [DataMember]
        public int? FavouriteSnapshots { get; private set; }
        
        [DataMember]
        public int? FavouriteMovies { get; private set; }
        
        [DataMember]
        public int? FavouriteCharacters { get; private set; }
        
        [DataMember]
        public int? FavouriteSeries { get; private set; }
        
        [DataMember]
        public IList<string> Friends { get; private set; }
        
        [DataMember]
        public IList<IMemorabilia> MemorabiliaList { get; private set; }
        
        [DataMember]
        public string ImageUrl { get; private set; }
    }
}

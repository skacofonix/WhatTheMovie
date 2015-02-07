using System.Collections.Generic;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public interface IUser : IWebsiteEntity
    {
        string Name { get; }

        string Level { get; }

        double? Score { get; }

        int? Age { get; }

        Gender Gender { get; }

        string Country { get; }

        int? PlayingSinceYear { get; }

        int? PlayingSinceMonth { get; }

        string About { get; }

        int? FeatureFilmsSolved { get; }

        int? SnapshotSolved { get; }

        decimal? ReceivingRating { get; }

        decimal? FavouritedRating { get; }

        int? UploadFeatureFilmSnapshots { get; }

        int? UploadSnapshotsOfTheDay { get; }

        int? UploadVaultSnapshots { get; }

        int? UploadRejectedSnapshots { get; }

        int? UploadCharacterSnapshots { get; }

        int? UploadTitleSnapshots { get; }

        int? UploadReplacementSnapshots { get; }

        int? FavouriteSnapshots { get; }

        int? FavouriteMovies { get; }

        int? FavouriteCharacters { get; }

        int? FavouriteSeries { get; }

        IList<string> Friends { get; }

        IList<IMemorabilia> MemorabiliaList { get; }

        string ImageUrl { get; }
    }
}
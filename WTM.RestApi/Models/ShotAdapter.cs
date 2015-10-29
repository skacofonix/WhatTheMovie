using System;
using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotAdapter : IShot
    {
        private readonly Crawler.Domain.Shot shot;

        public ShotAdapter(Crawler.Domain.Shot shot)
        {
            this.shot = shot;
        }

        public string FirstSolver => this.shot.FirstSolver;

        public Uri ImageUri => this.shot.ImageUri;

        public bool? IsBookmarked => this.shot.IsBookmarked;

        public bool? IsFavourited => this.shot.IsFavourited;

        public bool IsGore => this.shot.IsGore;

        public bool IsNudity => this.shot.IsNudity;

        public bool? IsSolutionAvailable => this.shot.IsSolutionAvailable;

        public bool? IsVoteDeletation => this.shot.IsVoteDeletation;

        public IList<string> Languages => this.shot.Languages;

        public string MovieId => this.shot.MovieId;

        public int? NbSolver => this.shot.NbSolver;

        public int? NumberOfDayBeforeSolution => this.shot.NumberOfDayBeforeSolution;

        public int NumberOfFavourited => this.shot.NumberOfFavourited;

        public string Poster => this.shot.Poster;

        public DateTime? PublidationDate => this.shot.PublidationDate;

        public int ShotId => this.shot.ShotId;

        public IList<string> Tags => this.shot.Tags;

        public string Updater => this.shot.Updater;
    }
}

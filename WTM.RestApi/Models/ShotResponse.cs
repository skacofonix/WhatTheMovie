using System;
using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotResponse : IResponse, IShot
    {
        private readonly IShot shot;

        public ShotResponse(IShot shot)
        {
            this.shot = shot;
        }

        public int ShotId => this.shot.ShotId;
        public Uri ImageUri => this.shot.ImageUri;
        public string MovieId => this.shot.MovieId;
        public string Poster => this.shot.Poster;
        public string Updater => this.shot.Updater;
        public string FirstSolver => this.shot.FirstSolver;
        public int? NbSolver => this.shot.NbSolver;
        public DateTime? PublidationDate => this.shot.PublidationDate;
        public int? NumberOfDayBeforeSolution => this.shot.NumberOfDayBeforeSolution;
        public bool IsGore => this.shot.IsGore;
        public bool IsNudity => this.shot.IsNudity;
        public IList<string> Tags => this.shot.Tags;
        public IList<string> Languages => this.shot.Languages;
        public bool? IsFavourited => this.shot.IsFavourited;
        public bool? IsBookmarked => this.shot.IsBookmarked;
        public bool? IsSolutionAvailable => this.shot.IsSolutionAvailable;
        public bool? IsVoteDeletation => this.shot.IsVoteDeletation;
        public int NumberOfFavourited => this.shot.NumberOfFavourited;
    }
}

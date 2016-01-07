using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotAdapter : IShot
    {
        private readonly Crawler.Domain.Shot shot;

        public ShotAdapter(Crawler.Domain.Shot shot)
        {
            this.shot = shot;
        }

        [DataMember(EmitDefaultValue = false)]
        public string FirstSolver => this.shot.FirstSolver;

        [DataMember]
        public Uri ImageUri => this.shot.ImageUri;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsBookmarked => this.shot.IsBookmarked;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsFavourited => this.shot.IsFavourited;

        [DataMember]
        public bool IsGore => this.shot.IsGore;

        [DataMember]
        public bool IsNudity => this.shot.IsNudity;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsSolutionAvailable => this.shot.IsSolutionAvailable;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsVoteDeletation => this.shot.IsVoteDeletation;

        [DataMember]
        public IList<string> Languages => this.shot.Languages;

        [DataMember(EmitDefaultValue = false)]
        public string MovieId => this.shot.MovieId;

        [DataMember]
        public int? NbSolver => this.shot.NbSolver;

        [DataMember(EmitDefaultValue = false)]
        public int? NumberOfDayBeforeSolution => this.shot.NumberOfDayBeforeSolution;

        [DataMember]
        public int NumberOfFavourited => this.shot.NumberOfFavourited;

        [DataMember]
        public string Poster => this.shot.Poster;

        [DataMember(EmitDefaultValue = false)]
        public DateTime? PublidationDate => this.shot.PublidationDate;

        [DataMember]
        public int ShotId => this.shot.ShotId;

        [DataMember(EmitDefaultValue = false)]
        public IList<string> Tags => this.shot.Tags;

        [DataMember(EmitDefaultValue = false)]
        public string Updater => this.shot.Updater;
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotResponse : IShotResponse
    {
        private readonly Crawler.Domain.Shot shot;

        public ShotResponse(Crawler.Domain.Shot shot)
        {
            this.shot = shot;
        }

        [DataMember]
        public int Id => this.shot.ShotId;

        [DataMember]
        public Uri Image => this.shot.ImageUri;

        [DataMember]
        public string Poster => this.shot.Poster;

        [DataMember(EmitDefaultValue = false)]
        public string Updater => this.shot.Updater;

        [DataMember(EmitDefaultValue = false)]
        public string FirstSolver => this.shot.FirstSolver;

        [DataMember]
        public int? NbSolver => this.shot.NbSolver;

        [DataMember]
        public DateTime PublidationDate => this.shot.PublidationDate.Value;

        [DataMember(EmitDefaultValue = false)]
        public int? NumberOfDayBeforeSolution => this.shot.NumberOfDayBeforeSolution;

        [DataMember]
        public ShotUserStatus UserStatus => ShotUserStatusAdapter.Adapt(this.shot.UserStatus);

        [DataMember]
        public bool IsGore => this.shot.IsGore;

        [DataMember]
        public bool IsNudity => this.shot.IsNudity;

        [DataMember]
        public IList<string> Tags => this.shot.Tags;

        [DataMember]
        public IList<string> Languages => this.shot.Languages;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsFavourited => this.shot.IsFavourited;

        [DataMember(EmitDefaultValue = false)]
        public int NumberOfFavourited => this.shot.NumberOfFavourited;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsBookmarked => this.shot.IsBookmarked;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsSolutionAvailable => this.shot.IsSolutionAvailable;

        [DataMember(EmitDefaultValue = false)]
        public bool? IsVoteDeletation => this.shot.IsVoteDeletation;
    }
}

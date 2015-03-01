using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class Shot : IWebsiteEntity
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public int ShotId { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public Uri ImageUri { get; set; }

        [DataMember(IsRequired = true)]
        public Navigation Navigation { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string MovieId { get; set; }

        [DataMember(IsRequired = true)]
        public string Poster { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Updater { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FirstSolver { get; set; }

        [DataMember(IsRequired = true)]
        public int? NbSolver { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime? PublidationDate { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime? SolutionDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SnapshotDifficulty? Difficulty { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ShotUserStatus? UserStatus { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsGore { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsNudity { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public IList<string> Tags { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public IList<string> Languages { get; set; }

        [DataMember(IsRequired = true)]
        public Rate Rate { get; set; }

        [IgnoreDataMember]
        public Movie Movie { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool? IsFavourited { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool? IsBookmarked { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool? IsSolutionAvailable { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool? IsVoteDeletation { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int NumberOfFavourited { get; set; }
    }
}
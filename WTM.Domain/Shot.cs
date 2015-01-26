using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class Shot : IShot
    {
        [DataMember(IsRequired = true, Order = 1)]
        public int WtmId { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public string ImageUri { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public User PostedBy { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public User FirstSolvedBy { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime PublidationDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SnapshotDifficulty Difficulty { get; set; }

        [IgnoreDataMember]
        public bool IsGore { get; set; }

        [IgnoreDataMember]
        public bool IsNudity { get; set; }

        [IgnoreDataMember]
        public List<Tag> Tags { get; set; }

        [IgnoreDataMember]
        public Movie Movie { get; set; }

        [IgnoreDataMember]
        public int DayRemainingBeforeSolution { get; set; }

        [DataMember]
        public DateTime DateSolution { get; set; }
    }
}
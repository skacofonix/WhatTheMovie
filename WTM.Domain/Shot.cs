using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class Shot : IShot
    {
        [DataMember(IsRequired = true, Order = 1)]
        public int ShotId { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public string ImageUri { get; set; }

        [DataMember(IsRequired = true)]
        public Navigation Navigation { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? MovieId { get; set; }

        [DataMember(IsRequired = true)]
        public string Poster { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Updater { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FirstSolver { get; set; }

        [DataMember(IsRequired = true)]
        public int NbSolver { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime PublidationDate { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime SolutionDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SnapshotDifficulty? Difficulty { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsGore { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsNudity { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> Tags { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> Languages { get; set; }

        [DataMember(IsRequired = true)]
        public Rate Rate { get; set; }

        [IgnoreDataMember]
        public Movie Movie { get; set; }
    }
}
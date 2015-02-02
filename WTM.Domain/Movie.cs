using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class Movie : IMovie
    {
        public Movie()
        {
            AlternativeTitles = new List<string>();
            Tags = new List<string>();
        }

        [DataMember(IsRequired = true)]
        public string OriginalTitle { get; private set; }

        [DataMember]
        public IList<string> GenreList { get; private set; }

        [DataMember]
        public string Director { get; private set; }

        [DataMember]
        public string Abstract { get; private set; }

        [DataMember]
        public int? Year { get; private set; }

        [DataMember]
        public IRate Rate { get; private set; }

        [DataMember]
        public IList<string> AlternativeTitles { get; private set; }

        [DataMember]
        public IList<string> Tags { get; private set; }

        [DataMember]
        public int? NumberOfSnapshot { get; private set; }

        [DataMember]
        public double? TotalSolves { get; private set; }

        [DataMember]
        public DateTime? IntroducedOn { get; private set; }

        [DataMember]
        public string IntroducedBy { get; private set; }

        [DataMember]
        public int? NumberOfReviews { get; private set; }
    }
}
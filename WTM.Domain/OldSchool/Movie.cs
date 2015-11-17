using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.OldSchool.Interfaces;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class Movie : IWebsiteEntity
    {
        public Movie()
        {
            AlternativeTitles = new List<string>();
            Tags = new List<string>();
        }

        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        public IList<ParseInfo> ParseInfos { get; set; }

        [DataMember(IsRequired = true)]
        public string OriginalTitle { get;  set; }

        [DataMember]
        public IList<string> GenreList { get;  set; }

        [DataMember]
        public string Director { get;  set; }

        [DataMember]
        public string Abstract { get;  set; }

        [DataMember]
        public int? Year { get;  set; }

        [DataMember]
        public Rate Rate { get; set; }

        [DataMember]
        public IList<string> AlternativeTitles { get;  set; }

        [DataMember]
        public IList<string> Tags { get;  set; }

        [DataMember]
        public int? NumberOfSnapshot { get;  set; }

        [DataMember]
        public double? TotalSolves { get;  set; }

        [DataMember]
        public DateTime? IntroducedOn { get;  set; }

        [DataMember]
        public string IntroducedBy { get;  set; }

        [DataMember]
        public int? NumberOfReviews { get; set; }
    }
}
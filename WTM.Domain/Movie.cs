﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

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
        public IRate Rate { get;  set; }

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
        public int? NumberOfReviews { get;  set; }

        [IgnoreDataMember]
        public DateTime ParseDateTime { get;  set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get;  set; }
    }
}
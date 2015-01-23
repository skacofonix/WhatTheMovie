using System;
using System.Collections.Generic;

namespace WTM.WebsiteClient.Domain
{
    internal class Movie : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }
        public string OriginalTitle { get; set; }
        public List<string> GenreList { get; set; }
        public string Director { get; set; }
        public string Abstract { get; set; }
        public int? Year { get; set; }
        public int? NumberOfRate { get; set; }
        public decimal? Rate { get; set; }
        public List<string> AlternativeTitles { get; set; }
        public List<string> Tags { get; set; }
        public int? NumberOfSnapshot { get; set; }
        public double? TotalSolves { get; set; }
        public DateTime? IntroducedOn { get; set; }
        public string IntroducedBy { get; set; }
        public int? NumberOfReviews { get; set; }

        public Movie()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}

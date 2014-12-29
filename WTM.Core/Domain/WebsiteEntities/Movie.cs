using System;
using System.Collections.Generic;

namespace WTM.Core.Domain.WebsiteEntities
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

        public Movie()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}

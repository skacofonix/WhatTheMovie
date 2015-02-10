using System;
using System.Collections.Generic;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class MovieSummaryCollection : IMovieSummaryCollection
    {
        public DateTime ParseDateTime { get; set; }
        public TimeSpan ParseDuration { get; set; }
        public DateTime? Date { get; set; }
        public IList<IMovieSummary> Movies { get; set; }
    }
}
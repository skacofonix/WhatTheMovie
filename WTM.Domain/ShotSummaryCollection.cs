using System;
using System.Collections.Generic;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class ShotSummaryCollection : IShotSummaryCollection
    {
        public DateTime ParseDateTime { get; set; }
        public TimeSpan ParseDuration { get; set; }
        public DateTime? Date { get; set; }
        public IList<IShotSummary> Shots { get; set; }
        public ShotType? ShotType { get; set; }
    }
}

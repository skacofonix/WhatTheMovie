﻿using System;
using System.Collections.Generic;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class MovieSummaryCollection : IMovieSummaryCollection
    {
        public DateTime ParseDateTime { get; private set; }
        public TimeSpan ParseDuration { get; private set; }
        public DateTime? Date { get; private set; }
        public IList<IMovieSummary> Movies { get; private set; }
    }
}
﻿using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotArchivesResponse
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
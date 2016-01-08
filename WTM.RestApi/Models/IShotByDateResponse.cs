using System;
using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotByDateResponse : IResponse, IPaginableResult
    {
        DateTime Date { get; }
        IEnumerable<IShotSummary> Items { get; }
    }
}
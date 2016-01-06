using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotSearchTagResponse : IResponse, IPaginableResult
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
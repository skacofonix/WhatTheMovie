using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotSearchTagResponse : IResponse, ISearchResult
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
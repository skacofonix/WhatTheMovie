using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotByDateResponse
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
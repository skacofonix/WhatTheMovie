using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotFeatureFilmsResponse
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
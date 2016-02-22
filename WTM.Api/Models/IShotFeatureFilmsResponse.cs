using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IShotFeatureFilmsResponse
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
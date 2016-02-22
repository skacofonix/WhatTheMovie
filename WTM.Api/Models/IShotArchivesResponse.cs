using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IShotArchivesResponse
    {
        IEnumerable<IShotSummary> Items { get; }
    }
}
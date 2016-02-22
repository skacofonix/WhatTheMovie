using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IShotNewSubmissionsResponse : IResponse
    {
        IEnumerable<IShotSummary> Items { get;  }
    }
}
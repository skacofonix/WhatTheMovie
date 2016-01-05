using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotNewSubmissionsResponse
    {
        IEnumerable<IShotSummary> Items { get;  }
    }
}
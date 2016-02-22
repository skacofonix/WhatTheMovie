using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IShotSearchTagResponse : IResponse, IPaginableResult
    {
        IEnumerable<ShotSearchTag> Items { get; }
    }
}
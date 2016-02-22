using System.Collections.Generic;

namespace WTM.Api.Models
{
    public interface IShotFavouritesResponse : IResponse, IPaginableResult
    {
        IEnumerable<IShotSummary> Items { get; set; }
    }
}
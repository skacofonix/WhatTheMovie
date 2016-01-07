using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public interface IShotFavouritesResponse : IResponse, IPaginableResult
    {
        IEnumerable<IShotSummary> Items { get; set; }
    }
}
using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotFavouritesResponse : IResponse, IShotFavouritesResponse
    {
        public IEnumerable<IShotSummary> Items { get; set; }
        public int DisplayCount { get; }
        public int TotalCount { get; }
        public IRange Range { get; }
    }
}
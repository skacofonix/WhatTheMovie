using System.Collections.Generic;

namespace WTM.RestApi.Models
{
    public class ShotFavouritesResponse : IShotFavouritesResponse
    {
        public IEnumerable<ShotOverviewResponse> Items { get; set; }
        public int TotalCount { get; }
        public IRange Range { get; }
    }
}
using System.Collections.Generic;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotFavouritesResponse : IResponse, IPaginableResult
    {
        public IEnumerable<ShotOverviewResponse> Items { get; set; }
        public int TotalCount { get; }
        public IRange Range { get; }
    }
}
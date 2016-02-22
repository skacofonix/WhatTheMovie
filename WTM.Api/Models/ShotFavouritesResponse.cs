using System.Collections.Generic;
using System.Linq;

namespace WTM.Api.Models
{
    public class ShotFavouritesResponse : IResponse, IShotFavouritesResponse
    {
        public ShotFavouritesResponse(IEnumerable<IShotSummary> items, int displayMin, int totalCount)
        {
            TotalCount = totalCount;
            DisplayMin = displayMin;
            Items = items;
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => this.Items.Count();
        public int DisplayMin { get; private set; }
        public int DisplayMax => this.DisplayMin + DisplayCount;
        public IEnumerable<IShotSummary> Items { get; set; }
    }
}
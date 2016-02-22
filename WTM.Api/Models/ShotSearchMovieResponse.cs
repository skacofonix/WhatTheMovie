using System.Collections.Generic;

namespace WTM.Api.Models
{
    public class ShotSearchMovieResponse : IShotSearchMovieResponse
    {
        public int TotalCount { get; }
        public int DisplayCount { get; }
        public int DisplayMin { get; }
        public int DisplayMax { get; }
        public IEnumerable<ShotSummary> Items { get; set; }
    }
}
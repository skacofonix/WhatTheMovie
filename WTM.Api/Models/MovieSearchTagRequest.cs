using System.Collections.Generic;

namespace WTM.Api.Models
{
    public class MovieSearchTagRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        public IEnumerable<MovieSummary> Items { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
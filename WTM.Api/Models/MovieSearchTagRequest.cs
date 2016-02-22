using System.Collections.Generic;

namespace WTM.Api.Models
{
    public class MovieSearchTagRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        public IEnumerable<MovieSummary> Items { get; set; }
        public int? Start { get; }
        public int? Limit { get; }
        public string Token { get; }
    }
}
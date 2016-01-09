using System;

namespace WTM.RestApi.Models
{
    public class ShotsRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        public DateTime? Date { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
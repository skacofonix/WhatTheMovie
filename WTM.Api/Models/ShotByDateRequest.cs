using System;

namespace WTM.Api.Models
{
    public class ShotByDateRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        public DateTime Date { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
using System;

namespace WTM.RestApi.Models
{
    public class ShotFeatureFilmsRequest : IRequest, IPaginable, IAuthenticable
    {
        public DateTime? Date { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
using System;
using WTM.RestApi.Models;

namespace WTM.RestApi.Controllers
{
    public class ShotFeatureFilmsRequest : IPaginable, IAuthenticable
    {
        public DateTime? Date { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
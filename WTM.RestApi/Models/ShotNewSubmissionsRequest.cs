using System;
using WTM.RestApi.Models;

namespace WTM.RestApi.Controllers
{
    public class ShotNewSubmissionsRequest : IPaginable, IAuthenticable
    {
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
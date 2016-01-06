using System;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class ShotByDateRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        [Required]
        public DateTime Date { get; set; }
        public int? Start { get; }
        public int? Limit { get; }
        public string Token { get; }
    }
}
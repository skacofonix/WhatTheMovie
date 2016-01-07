using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        [Required]
        public List<string> Tags { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
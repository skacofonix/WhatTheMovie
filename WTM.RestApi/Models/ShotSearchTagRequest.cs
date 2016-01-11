using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        [Required]
        [MinLength(3)]
        public string Tag { get; set; }
        public int? Start { get; set; }
        public int? Limit { get; set; }
        public string Token { get; set; }
    }
}
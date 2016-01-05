using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class ShotSearchTagRequest : IPaginable, IAuthenticable
    {
        [Required]
        public List<string> Tags { get; set; }
        public int? Start { get; }
        public int? Limit { get; }
        public string Token { get; }
    }
}
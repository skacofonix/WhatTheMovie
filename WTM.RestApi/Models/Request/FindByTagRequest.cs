using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class FindByTagRequest : IPaginableRequest, IAuthenticableRequest
    {
        [Required]
        public List<string> Tags { get; set; }

        public int? Start { get; set; }

        [Range(5, 100)]
        public int? Limit { get; set; }

        public string Token { get; set; }
    }
}
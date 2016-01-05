using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class RateRequest : IRequest, IAuthenticable
    {
        [Required]
        [Range(0, 10)]
        public int Rate { get; set; }

        public string Token { get; set; }
    }
}
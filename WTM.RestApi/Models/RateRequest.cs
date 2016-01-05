using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class RateRequest : IAuthenticable
    {
        [Required]
        [Range(0, 10)]
        public int Rate { get; set; }

        public string Token { get; set; }
    }
}
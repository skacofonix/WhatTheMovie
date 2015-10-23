using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class RateRequest : IAuthenticableRequest
    {
        [Required]
        [Range(0, 10)]
        public int Rate { get; set; }

        public string Token { get; set; }
    }
}
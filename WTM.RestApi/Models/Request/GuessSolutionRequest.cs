using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class GuessSolutionRequest : IAuthenticableRequest
    {
        [Required]
        public string Title { get; set; }

        public string Token { get; set; }
    }
}
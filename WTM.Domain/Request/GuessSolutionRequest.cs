using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class GuessSolutionRequest : IAuthenticableRequest
    {
        [Required]
        public string Title { get; set; }

        public string Token { get; set; }
    }
}
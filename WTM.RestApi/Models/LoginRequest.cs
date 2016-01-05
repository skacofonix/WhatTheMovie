using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class LoginRequest : IRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
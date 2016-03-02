using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class UserLogoutRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
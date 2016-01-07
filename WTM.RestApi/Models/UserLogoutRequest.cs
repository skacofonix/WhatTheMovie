using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class UserLogoutRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; }
    }
}
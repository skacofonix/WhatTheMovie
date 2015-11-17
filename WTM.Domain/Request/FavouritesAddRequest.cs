using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class FavouritesAddRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
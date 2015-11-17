using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class FavouritesDeleteRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
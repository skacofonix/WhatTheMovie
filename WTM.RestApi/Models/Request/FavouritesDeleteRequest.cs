using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class FavouritesDeleteRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
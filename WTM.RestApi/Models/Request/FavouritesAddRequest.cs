using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class FavouritesAddRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
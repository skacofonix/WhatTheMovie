using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class FavouritesAddRequest : IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
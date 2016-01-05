using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class FavouritesAddRequest : IRequest,  IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
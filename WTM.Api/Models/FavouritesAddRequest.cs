using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class FavouritesAddRequest : IRequest,  IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
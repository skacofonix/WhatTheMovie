using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class FavouritesDeleteRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class FavouritesDeleteRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
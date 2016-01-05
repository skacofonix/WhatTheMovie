using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class FavouritesGetRequest : IAuthenticable, IPaginable
    {
        [Required]
        public string Token { get; set; }

        public int? Start { get; set; }

        public int? Limit { get; set; }
    }
}
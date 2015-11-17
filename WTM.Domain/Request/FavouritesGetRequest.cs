using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class FavouritesGetRequest : IAuthenticableRequest, IPaginableRequest
    {
        [Required]
        public string Token { get; set; }

        public int? Start { get; set; }

        public int? Limit { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class BookmarksGetRequest : IRequest, IAuthenticable, IPaginableRequest
    {
        [Required]
        public string Token { get; set; }

        public int? Start { get; set; }

        public int? Limit { get; set; }
    }
}
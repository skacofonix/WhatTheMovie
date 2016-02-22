using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class BookmarksAddRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
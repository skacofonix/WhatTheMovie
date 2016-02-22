using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class BookmarksDeleteRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
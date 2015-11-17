using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class BookmarksDeleteRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
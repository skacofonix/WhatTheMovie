using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class BookmarksAddRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
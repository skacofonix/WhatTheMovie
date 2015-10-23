using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class BookmarksAddRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
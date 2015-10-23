using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class BookmarksDeleteRequest : IAuthenticableRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
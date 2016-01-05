using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class BookmarksAddRequest : IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
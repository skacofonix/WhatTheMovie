using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class BookmarksDeleteRequest : IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
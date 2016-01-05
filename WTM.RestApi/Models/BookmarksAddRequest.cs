using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class BookmarksAddRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
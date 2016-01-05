using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class BookmarksDeleteRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Token { get; set; }
    }
}
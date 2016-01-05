using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class TagsAddRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Tag { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
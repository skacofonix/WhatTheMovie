using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class TagsDeleteRequest : IAuthenticable
    {
        [Required]
        public string Tag { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
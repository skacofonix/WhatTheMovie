using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class TagsDeleteRequest : IAuthenticableRequest
    {
        [Required]
        public string Tag { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
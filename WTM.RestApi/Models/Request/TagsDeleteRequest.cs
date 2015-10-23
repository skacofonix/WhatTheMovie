using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class TagsDeleteRequest : IAuthenticableRequest
    {
        [Required]
        public string Tag { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
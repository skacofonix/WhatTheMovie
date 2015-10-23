using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class TagsAddRequest : IAuthenticableRequest
    {
        [Required]
        public string Tag { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
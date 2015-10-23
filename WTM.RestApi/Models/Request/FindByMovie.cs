using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models.Request
{
    public class FindByMovie : IAuthenticableRequest
    {
        [Required]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
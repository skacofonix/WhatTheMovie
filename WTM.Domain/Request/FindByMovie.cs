using System.ComponentModel.DataAnnotations;

namespace WTM.Domain.Request
{
    public class FindByMovie : IAuthenticableRequest
    {
        [Required]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
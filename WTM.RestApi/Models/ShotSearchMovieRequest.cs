using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class ShotSearchMovieRequest : IAuthenticable
    {
        [Required]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
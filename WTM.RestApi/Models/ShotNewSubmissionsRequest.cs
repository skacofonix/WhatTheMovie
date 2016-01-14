using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class ShotNewSubmissionsRequest : IRequest, IPaginableRequest, IAuthenticable, IShotCollectionRequest
    {
        public int? Start { get; set; }
        public int? Limit { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
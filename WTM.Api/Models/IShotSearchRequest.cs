using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public interface IShotSearchRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        [Required]
        [MinLength(3)]
        string Tag { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public interface IShotSearchRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        [Required]
        [MinLength(3)]
        string Tag { get; }
    }
}
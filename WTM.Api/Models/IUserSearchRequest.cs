using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public interface IUserSearchRequest : IRequest, IPaginableRequest
    {
        [Required]
        string Filter { get; }

        int? Start { get; }

        int? Limit { get; }
    }
}
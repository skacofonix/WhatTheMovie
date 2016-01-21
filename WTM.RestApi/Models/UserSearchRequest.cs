using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public interface IUserSearchRequest : IRequest
    {
        [Required]
        string Filter { get; }

        int? Start { get; }

        [Range(5, 100)]
        int? Limit { get; }
    }

    public class UserSearchRequest: IUserSearchRequest
    {
        [Required]
        public string Filter { get; set; }

        public int? Start { get; set; }

        [Range(5, 100)]
        public int? Limit { get; set; }
    }
}
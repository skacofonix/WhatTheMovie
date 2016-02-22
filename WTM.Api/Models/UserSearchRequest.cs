using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class UserSearchRequest: IUserSearchRequest
    {
        [Required]
        public string Filter { get; set; }

        public int? Start { get; set; }

        [Range(5, 100)]
        public int? Limit { get; set; }
    }
}
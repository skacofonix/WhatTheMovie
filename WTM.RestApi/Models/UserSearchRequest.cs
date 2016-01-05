using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class UserSearchRequest
    {
        [Required]
        public string Filter { get; set; }

        public int? Start { get; set; }

        [Range(5, 100)]
        public int? Limit { get; set; }
    }
}
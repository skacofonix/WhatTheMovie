using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public interface IShotSummary
    {
        [Required]
        int Id { get; }

        //[Required]
        //Uri Image { get; }

        [Required]
        string Thumb { get; }

        [Required]
        ShotUserStatus Status { get; }
    }
}
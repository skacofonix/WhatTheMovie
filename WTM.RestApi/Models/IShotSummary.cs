using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public interface IShotSummary
    {
        [Required]
        int Id { get; }

        [Required]
        Uri Image { get; }

        [Required]
        ShotUserStatus Status { get; }
    }
}
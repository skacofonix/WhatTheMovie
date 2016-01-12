using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public interface IShotSummary
    {
        [Required]
        int ShotId { get; }

        [Required]
        Uri ImageUri { get; }

        [DataMember(EmitDefaultValue = false)]
        ShotUserStatus? UserStatus { get; }
    }
}
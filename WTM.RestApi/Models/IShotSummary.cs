using System;

namespace WTM.RestApi.Models
{
    public interface IShotSummary
    {
        int ShotId { get; }
        Uri ImageUri { get; }
        ShotUserStatus UserStatus { get; }
    }
}
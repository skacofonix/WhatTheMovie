using System;

namespace WTM.RestApi.Models
{
    public class ShotSummary : IShotSummary
    {
        public int ShotId { get; set; }

        public Uri ImageUri { get; set; }

        public ShotUserStatus UserStatus { get; set; }
    }
}
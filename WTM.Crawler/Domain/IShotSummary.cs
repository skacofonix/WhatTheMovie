using System;

namespace WTM.Crawler.Domain
{
    public interface IShotSummary
    {
        int ShotId { get; }
        Uri ImageUri { get; }
        ShotUserStatus UserStatus { get;}
    }
}
using System;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public static class ShotUserStatusAdapter
    {
        public static ShotUserStatus Adapt(WTM.Crawler.Domain.ShotUserStatus source)
        {
            switch (source)
            {
                case Crawler.Domain.ShotUserStatus.Unsolved:
                    return ShotUserStatus.Unsolved;
                case Crawler.Domain.ShotUserStatus.Solved:
                    return ShotUserStatus.Solved;
                case Crawler.Domain.ShotUserStatus.NeverSolved:
                    return ShotUserStatus.NeverSolved;
                case Crawler.Domain.ShotUserStatus.Uploaded:
                    return ShotUserStatus.Uploaded;
                case Crawler.Domain.ShotUserStatus.Requested:
                    return ShotUserStatus.Requested;
                default:
                    throw new ArgumentOutOfRangeException(nameof(source), source, null);
            }
        }
    }
}
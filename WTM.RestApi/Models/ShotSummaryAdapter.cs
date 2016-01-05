using System;

namespace WTM.RestApi.Models
{
    public class ShotSummaryAdapter : IShotSummary
    {
        private readonly Crawler.Domain.IShotSummary crawlerShotSummary;

        public ShotSummaryAdapter(WTM.Crawler.Domain.IShotSummary crawlerShotSummary)
        {
            this.crawlerShotSummary = crawlerShotSummary;
        }

        public int ShotId => this.crawlerShotSummary.ShotId;

        public Uri ImageUri => this.crawlerShotSummary.ImageUri;

        public ShotUserStatus UserStatus => this.ShotUserStatusAdapter(this.crawlerShotSummary.UserStatus);

        private ShotUserStatus ShotUserStatusAdapter(WTM.Crawler.Domain.ShotUserStatus crawlerUserStatus)
        {
            switch (crawlerUserStatus)
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
                    throw new ArgumentOutOfRangeException(nameof(crawlerUserStatus), crawlerUserStatus, null);
            }
        }
    }
}
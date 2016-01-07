using System;
using WTM.Crawler.Domain;

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

        public ShotUserStatus UserStatus => ShotUserStatusAdapter.Adapt(this.crawlerShotSummary.UserStatus);
    }
}
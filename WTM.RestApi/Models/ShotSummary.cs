using System;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class ShotSummary : IShotSummary
    {
        private readonly Crawler.Domain.IShotSummary crawlerShotSummary;

        public ShotSummary(Crawler.Domain.IShotSummary crawlerShotSummary)
        {
            this.crawlerShotSummary = crawlerShotSummary;
        }

        [Required]
        public int Id => this.crawlerShotSummary.ShotId;

        [Required]
        public Uri Image => this.crawlerShotSummary.ImageUri;

        [Required]
        public ShotUserStatus Status => ShotUserStatusAdapter.Adapt(this.crawlerShotSummary.UserStatus);
    }
}
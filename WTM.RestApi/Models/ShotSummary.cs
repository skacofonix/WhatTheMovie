using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
        public int ShotId => this.crawlerShotSummary.ShotId;

        [Required]
        public Uri ImageUri => this.crawlerShotSummary.ImageUri;

        [DataMember(EmitDefaultValue = false)]
        public ShotUserStatus? UserStatus => ShotUserStatusAdapter.Adapt(this.crawlerShotSummary.UserStatus);
    }
}
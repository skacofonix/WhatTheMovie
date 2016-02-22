using System;
using System.ComponentModel.DataAnnotations;

namespace WTM.Api.Models
{
    public class ShotSearchTag
    {
        public ShotSearchTag(Crawler.Domain.IShotSummary shotSummary)
        {
            this.Id = shotSummary.ShotId;
            this.Image = shotSummary.ImageUri;
        }

        [Required]
        public int Id { get; private set; }

        [Required]
        public Uri Image { get; private set; }
    }
}
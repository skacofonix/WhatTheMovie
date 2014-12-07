using System;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class OverviewShot : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        public string ImageUrl { get; private set; }
        public int? ShotId { get; private set; }
        public bool Unsolved { get; set; }

        public OverviewShot(string imageUrl, int? shotId, bool unsolved)
        {
            ImageUrl = imageUrl;
            ShotId = shotId;
            Unsolved = unsolved;
        }

    }
}

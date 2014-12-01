using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class OverviewShot : IWebsiteEntityBase
    {
        public string ImageUrl { get; private set; }
        public int? ShotId { get; private set; }

        public OverviewShot(string imageUrl, int? shotId)
        {
            ImageUrl = imageUrl;
            ShotId = shotId;
        }
    }
}

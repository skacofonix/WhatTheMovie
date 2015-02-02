using System;

namespace WTM.WebsiteClient.Domain
{
    public class OverviewShot : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        public string ImageUrl { get; private set; }
        public int? ShotId { get; private set; }
        public ShotSolveStatus? ShotSolveStatus { get; private set; }

        public OverviewShot(string imageUrl, int? shotId, ShotSolveStatus? shotSolveStatus)
        {
            ImageUrl = imageUrl;
            ShotId = shotId;
            ShotSolveStatus = shotSolveStatus;
        }
    }
}

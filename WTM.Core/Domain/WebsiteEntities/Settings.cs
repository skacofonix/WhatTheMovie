using System;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class Settings : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; set; }

        #region Filters

        public bool? ShowGore { get; set; }

        public bool? ShowNudity { get; set; }

        #endregion
    }
}

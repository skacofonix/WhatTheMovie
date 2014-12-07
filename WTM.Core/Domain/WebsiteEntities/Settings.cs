using System;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class Settings : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        #region Filters

        public bool? ShowGore { get; private set; }

        public bool? ShowNudity { get; private set; }

        #endregion
    }
}

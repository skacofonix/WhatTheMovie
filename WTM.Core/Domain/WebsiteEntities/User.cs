using System;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class User : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }

        public User()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}

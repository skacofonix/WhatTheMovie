using System;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class Movie : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }
        
        public string OriginalTitle { get; set; }
    }
}

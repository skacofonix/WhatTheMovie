using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class Movie : IWebsiteEntityBase
    {
        public string OriginalTitle { get; set; }
    }
}

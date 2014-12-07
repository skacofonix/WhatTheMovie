using System;

namespace WTM.Core.Domain.WebsiteEntities
{
    public interface IWebsiteEntityBase
    {
        DateTime ParseDateTime { get; }
    }
}

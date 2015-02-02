using System;

namespace WTM.WebsiteClient.Domain
{
    public interface IWebsiteEntityBase
    {
        DateTime ParseDateTime { get; }
    }
}

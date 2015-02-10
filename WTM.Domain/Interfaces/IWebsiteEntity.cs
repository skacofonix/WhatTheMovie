using System;

namespace WTM.Domain.Interfaces
{
    public interface IWebsiteEntity
    {
        DateTime ParseDateTime { get; set; }

        TimeSpan ParseDuration { get; set; }
    }
}
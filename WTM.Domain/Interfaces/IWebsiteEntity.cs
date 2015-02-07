using System;

namespace WTM.Domain.Interfaces
{
    public interface IWebsiteEntity
    {
        DateTime ParseDateTime { get; }

        TimeSpan ParseDuration { get; }
    }
}
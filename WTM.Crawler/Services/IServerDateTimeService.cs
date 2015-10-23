using System;

namespace WTM.Crawler.Services
{
    public interface IServerDateTimeService
    {
        DateTime? GetDateTime();
    }
}
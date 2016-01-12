using System;
using System.Collections.Generic;

namespace WTM.Crawler.Domain
{
    public interface IWebsiteEntity
    {
        DateTime ParseDateTime { get; set; }

        TimeSpan ParseDuration { get; set; }

        IList<ParseInfo> ParseInfos { get; set; }

        string ConnectedUsername { get; set; }
    }
}
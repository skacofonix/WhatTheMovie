﻿using System;
using System.Collections.Generic;

namespace WTM.Domain.Interfaces
{
    public interface IWebsiteEntity
    {
        DateTime ParseDateTime { get; set; }

        TimeSpan ParseDuration { get; set; }

        IList<ParseInfo> ParseInfos { get; set; }
    }
}
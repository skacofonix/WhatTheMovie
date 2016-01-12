﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class UserSummary : IWebsiteEntity
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        public string ConnectedUsername { get; set; }

        [DataMember(IsRequired = true, Order = 1, EmitDefaultValue = true)]
        public string Username { get; set; }

        [DataMember(IsRequired = true, Order = 2, EmitDefaultValue = true)]
        public string Rank { get; set; }

        [DataMember(IsRequired = true, Order = 3, EmitDefaultValue = true)]
        public string Status { get; set; }

        [DataMember(IsRequired = true, Order = 4, EmitDefaultValue = false)]
        public Uri AvatarUrl { get; set; }

        public Uri ProfilUrl { get; set; }

        [DataMember(IsRequired = false, Order = 5, EmitDefaultValue = false)]
        public string Country { get; set; }

    }
}